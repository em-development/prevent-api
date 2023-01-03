using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.SearchSync
{
    public class SearchSyncQuery : FilterParams, IRequest<PagedResponse<IEnumerable<LegalEntitySyncDTO>>>
    {
        public string? Filter { get; set; }
        public bool OnlyDifferent { get; set; }
    }
}