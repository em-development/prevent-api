using Application.Wrappers;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.Search
{
    public class SearchQuery : FilterParams, IRequest<PagedResponse<IEnumerable<UserDto>>>
    {
        public string? Filter { get; set; }
    }
}