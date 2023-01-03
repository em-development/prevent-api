using System.Net.Http.Headers;
using System.Net.Http.Json;
using Adapters.Context;
using Adapters.Repositories.Settings.Users;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Users;
using Domain.Enums.Settings.Users;
using DTO.Settings.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Settings.Users.Commands.CreateUser
{
    internal class CreateUserHandler : IRequestHandler<CreateUserRequest, Response<UserFormDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _usersRepository;
        private readonly IUsersProfilesRepository _usersProfilesRepository;
        private readonly IUsersLegalEntitiesRepository _usersLegalEntitiesRepository;
        private readonly IMapper _mapper;
        private readonly ISessionContext _sessionContext;

        public CreateUserHandler(
            IConfiguration configuration,
            IUsersRepository usersRepository,
            IUsersProfilesRepository usersProfilesRepository,
            IUsersLegalEntitiesRepository usersLegalEntitiesRepository,
            IMapper mapper, ISessionContext sessionContext)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
            _usersProfilesRepository = usersProfilesRepository;
            _usersLegalEntitiesRepository = usersLegalEntitiesRepository;
            _mapper = mapper;
            _sessionContext = sessionContext;
        }

        public async Task<Response<UserFormDto>> Handle(
            CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetByUId(request.Uid);

            if (user != null)
            {
                throw new UserAlreadyExistsException();
            }

            user = new User(request.Name, request.Email, request.Uid);

            user = await _usersRepository.InsertAsync(user);

            foreach (var legalEntityId in request.LegalEntityIds)
            {
                var legalEntity = new UsersLegalEntities(user.Id, legalEntityId);
                await _usersLegalEntitiesRepository.InsertAsync(legalEntity);
            }

            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_configuration.GetSection("AccountAPI:URL").Value);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _sessionContext.GetToken());

            foreach (var userProfileId in request.UserProfileIds)
            {
                var userProfile = new UsersProfiles(user.Id, (UserProfileEnum) userProfileId);
                userProfile = await _usersProfilesRepository.InsertAsync(userProfile);

                const string requestUrl = "users/add-profile/";

                await httpClient.PostAsJsonAsync(requestUrl, new
                {
                    uid = request.Uid,
                    source = _configuration.GetSection("AccountAPI:Token").Value,
                    level = userProfile.UserProfileId
                }, cancellationToken);
            }

            var userDto = _mapper.Map<UserFormDto>(user);

            userDto.LegalEntityIds = request.LegalEntityIds;
            userDto.UserProfileIds = request.UserProfileIds;

            return new Response<UserFormDto>(userDto);
        }
    }
}