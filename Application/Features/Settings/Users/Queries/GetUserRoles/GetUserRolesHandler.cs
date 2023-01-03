using Adapters.Context;
using Adapters.Repositories.Settings.Users;
using Application.Exceptions.Context;
using Application.Wrappers;
using AutoMapper;
using Domain.Enums.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetUserRoles
{
    public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, Response<IEnumerable<UserProfileEnum>>>
    {
        private readonly IUsersProfilesRepository _usersProfilesRepository;

        private readonly ISessionContext _sessionContext;

        public GetUserRolesHandler(
            ISessionContext sessionContext,
            IUsersProfilesRepository usersProfilesRepository)
        {
            _sessionContext = sessionContext;
            _usersProfilesRepository = usersProfilesRepository;
        }

        public async Task<Response<IEnumerable<UserProfileEnum>>> Handle(GetUserRolesQuery query,
            CancellationToken cancellationToken)
        {
            if (_sessionContext.UserSession == null)
            {
                throw new UserNotRegisteredInSessionException();
            }

            var userRoles = await _usersProfilesRepository.GetUsersProfilesByUserId(_sessionContext.UserSession.Id);

            return new Response<IEnumerable<UserProfileEnum>>(userRoles != null
                ? userRoles.Select(x => (UserProfileEnum) x)
                : new List<UserProfileEnum>());
        }
    }
}