using Application.Wrappers;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.SearchSync
{
    public class SearchSyncQuery : FilterParams, IRequest<PagedResponse<IEnumerable<PropertySyncDTO>>>
    {
        public string? Filter { get; set; }
        public bool OnlyDifferent { get; set; }
    }
}