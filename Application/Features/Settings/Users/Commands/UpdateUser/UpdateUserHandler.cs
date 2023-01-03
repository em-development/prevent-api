using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using Adapters.Context;
using Adapters.Repositories.Settings.Users;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Users;
using Domain.Enums.Settings.Users;
using DTO.Settings.Users;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Features.Settings.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Response<UserFormDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _usersRepository;
        private readonly IUsersLegalEntitiesRepository _usersLegalEntitiesRepository;
        private readonly IUsersProfilesRepository _usersProfilesRepository;
        private readonly IMapper _mapper;
        private readonly ISessionContext _sessionContext;

        public UpdateUserHandler(
            IConfiguration configuration,
            IUsersRepository usersRepository,
            IUsersLegalEntitiesRepository usersLegalEntitiesRepository,
            IUsersProfilesRepository usersProfilesRepository,
            IMapper mapper,
            ISessionContext sessionContext)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
            _usersLegalEntitiesRepository = usersLegalEntitiesRepository;
            _usersProfilesRepository = usersProfilesRepository;
            _mapper = mapper;
            _sessionContext = sessionContext;
        }

        public async Task<Response<UserFormDto>> Handle(
            UpdateUserRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException("api-entity-user",
                    ("api-entity-user-field-id", request.Id)
                );
            }

            user.UpdateName(request.Name);
            user.UpdateEmail(request.Email);
            user.UpdateUId(request.Uid);

            await _usersRepository.UpdateAsync(user);

            user = await _usersRepository.GetByIdAsync(user.Id);

            #region UsersLegalEntities

            var currentUserLegalEntityIds = await _usersLegalEntitiesRepository.GetLegalEntitiesByUserId(user.Id);

            var toInsertUserLegalEntityIds = request.LegalEntityIds == null
                ? Array.Empty<int>()
                : request.LegalEntityIds.Except(currentUserLegalEntityIds);

            var toRemoveUserLegalEntityIds =
                currentUserLegalEntityIds.Except(request.LegalEntityIds ?? Array.Empty<int>());

            foreach (var legalEntityId in toInsertUserLegalEntityIds)
            {
                var newUserLegalEntity = new UsersLegalEntities(user.Id, legalEntityId);
                await _usersLegalEntitiesRepository.InsertAsync(newUserLegalEntity);
            }

            foreach (var legalEntityId in toRemoveUserLegalEntityIds)
            {
                var removeUserLegalEntity =
                    await _usersLegalEntitiesRepository.GetByUserIdAndLegalEntityId(request.Id, legalEntityId);
                if (removeUserLegalEntity != null)
                {
                    await _usersLegalEntitiesRepository.RemoveAsync(removeUserLegalEntity);
                }
            }

            #endregion

            #region UsersProfiles

            var requestUserProfilesIds = request.UserProfileIds;
            var currentUserProfilesIds = await _usersProfilesRepository.GetUsersProfilesByUserId(user.Id);

            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_configuration.GetSection("AccountAPI:URL").Value);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _sessionContext.GetToken());

            currentUserProfilesIds = currentUserProfilesIds.ToList();

            foreach (var userProfileId in currentUserProfilesIds)
            {
                const string requestUrl = "users/add-profile/";

                await httpClient.PostAsJsonAsync(requestUrl, new
                {
                    uid = request.Uid,
                    source = _configuration.GetSection("AccountAPI:Token").Value,
                    level = userProfileId
                }, cancellationToken);
            }

            var toInsertUserProfileIds = requestUserProfilesIds.Except(currentUserProfilesIds);

            var toRemoveUserProfileIds = currentUserProfilesIds.Except(request.UserProfileIds);

            foreach (var userProfileId in toInsertUserProfileIds)
            {
                var newUserProfile = new UsersProfiles(user.Id, (UserProfileEnum) userProfileId);
                await _usersProfilesRepository.InsertAsync(newUserProfile);

                const string requestUrl = "users/add-profile/";

                await httpClient.PostAsJsonAsync(requestUrl, new
                {
                    uid = request.Uid,
                    source = _configuration.GetSection("AccountAPI:Token").Value,
                    level = userProfileId
                }, cancellationToken);
            }

            foreach (var userProfileId in toRemoveUserProfileIds)
            {
                var removeUserProfile =
                    await _usersProfilesRepository.GetByUserIdAndUserProfileId(request.Id, userProfileId);

                if (removeUserProfile == null) continue;

                await _usersProfilesRepository.RemoveAsync(removeUserProfile);

                const string requestUrl = "users/remove-profile/";

                var json = JsonConvert.SerializeObject(new
                {
                    uid = request.Uid,
                    source = _configuration.GetSection("AccountAPI:Token").Value,
                    level = userProfileId
                });

                await httpClient.SendAsync(
                    new HttpRequestMessage(HttpMethod.Delete, requestUrl)
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    }, cancellationToken);
            }

            #endregion

            var userDto = _mapper.Map<UserFormDto>(user);

            userDto.LegalEntityIds = request.LegalEntityIds;
            userDto.UserProfileIds = request.UserProfileIds;

            return new Response<UserFormDto>(userDto);
        }
    }
}