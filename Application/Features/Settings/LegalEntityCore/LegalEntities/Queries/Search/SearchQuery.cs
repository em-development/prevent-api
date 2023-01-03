using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.Search
{
    public class SearchQuery : FilterParams, IRequest<PagedResponse<IEnumerable<LegalEntityDTO>>>
    {
        public string? Filter { get; set; }
    }
}