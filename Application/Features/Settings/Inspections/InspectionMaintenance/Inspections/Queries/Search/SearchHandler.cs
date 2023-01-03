using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Application.Wrappers;
using AutoMapper;
using Domain.Compacts.Settings.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<CompactInspectionDTO>>>
    {
        private readonly ICompactInspectionRepository _compactInspectionRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            ICompactInspectionRepository compactInspectionRepository,
            IMapper mapper
            )
        {
            _compactInspectionRepository = compactInspectionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<CompactInspectionDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<CompactInspection> inspections = _compactInspectionRepository.SearchToDashboard(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await inspections.Paginate<CompactInspection, CompactInspectionDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
