using Adapters.Context;
using Application.Exceptions.Context;
using Application.Wrappers;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, Response<CompactUserDTO>>
    {
        private readonly ISessionContext _sessionContext;

        public GetUserHandler(
            ISessionContext sessionContext
        )
        {
            _sessionContext = sessionContext;
        }

        public async Task<Response<CompactUserDTO>> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            if (_sessionContext.UserSession == null)
            {
                throw new UserNotRegisteredInSessionException();
            }

            var task = new Task<Response<CompactUserDTO>>(() =>
                new Response<CompactUserDTO>(_sessionContext.UserSession));

            return await task;
        }
    }
}