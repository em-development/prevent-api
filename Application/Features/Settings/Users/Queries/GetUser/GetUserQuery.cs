using Application.Wrappers;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<Response<CompactUserDTO>>
    {
    }
}
