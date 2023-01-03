using Application.Wrappers;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.Search
{
    public class SearchQuery : FilterParams, IRequest<PagedResponse<IEnumerable<PropertyDTO>>>
    {
        public string? Filter { get; set; }
    }
}