using Application.Wrappers;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetInspectors
{
    public class GetInspectorsQuery : IRequest<Response<IEnumerable<UserDto>>>
    {
        public int Id { get; set; }
    }
}