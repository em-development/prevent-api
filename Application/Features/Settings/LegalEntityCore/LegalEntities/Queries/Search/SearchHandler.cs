using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<LegalEntityDTO>>>
    {
        private readonly ILegalEntityRepository _legalEntityRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            ILegalEntityRepository legalEntityRepository,
            IMapper mapper
            )
        {
            _legalEntityRepository = legalEntityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LegalEntityDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            var legalEntities = _legalEntityRepository.SearchToDashboard(
                filter: query.Filter,
                current: query.Current,
                limit: query.Limit,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await legalEntities.Paginate<LegalEntity, LegalEntityDTO>(query.Current, query.Limit, _mapper);
        }
    }
}