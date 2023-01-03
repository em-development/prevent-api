using Application.Wrappers;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.Search
{
    public class SearchByLegalEntityIdQuery : FilterParams, IRequest<PagedResponse<IEnumerable<PropertyDTO>>>
    {
        public int LegalEntityId { get; set; }
        public string? Filter { get; set; }
    }
}