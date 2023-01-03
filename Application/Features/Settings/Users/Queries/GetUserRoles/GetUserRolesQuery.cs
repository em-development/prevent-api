using Application.Wrappers;
using Domain.Enums.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetUserRoles
{
    public class GetUserRolesQuery : IRequest<Response<IEnumerable<UserProfileEnum>>>
    {
    }
}