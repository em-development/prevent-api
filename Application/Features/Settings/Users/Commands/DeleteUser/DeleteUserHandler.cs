using System.Net.Http.Headers;
using System.Text;
using Adapters.Context;
using Adapters.Repositories.Settings.Users;
using Application.Exceptions.Common;
using Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Features.Settings.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Response<bool>>
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _usersRepository;
        private readonly IUsersLegalEntitiesRepository _usersLegalEntitiesRepository;
        private readonly IUsersProfilesRepository _usersProfilesRepository;
        private readonly ISessionContext _sessionContext;

        public DeleteUserHandler(
            IConfiguration configuration,
            IUsersRepository usersRepository,
            IUsersLegalEntitiesRepository usersLegalEntitiesRepository,
            IUsersProfilesRepository usersProfilesRepository,
            ISessionContext sessionContext)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
            _usersLegalEntitiesRepository = usersLegalEntitiesRepository;
            _usersProfilesRepository = usersProfilesRepository;
            _sessionContext = sessionContext;
        }

        public async Task<Response<bool>> Handle(
            DeleteUserRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException("api-entity-user",
                    ("api-entity-user-field-id", request.Id)
                );
            }

            var currentUserProfilesIds = await _usersProfilesRepository.GetUsersProfilesByUserId(request.Id);

            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_configuration.GetSection("AccountAPI:URL").Value);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _sessionContext.GetToken());

            foreach (var userProfileId in currentUserProfilesIds)
            {
                const string requestUrl = "users/remove-profile/";

                var json = JsonConvert.SerializeObject(new
                {
                    uid = user.UId!.Value,
                    source = _configuration.GetSection("AccountAPI:Token").Value,
                    level = userProfileId
                });

                await httpClient.SendAsync(
                    new HttpRequestMessage(HttpMethod.Delete, requestUrl)
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    }, cancellationToken);
            }

            await _usersLegalEntitiesRepository.RemoveAllByUserId(request.Id);

            await _usersProfilesRepository.RemoveAllByUserId(request.Id);

            await _usersRepository.RemoveAsync(user);

            return new Response<bool>(data: true);
        }
    }
}