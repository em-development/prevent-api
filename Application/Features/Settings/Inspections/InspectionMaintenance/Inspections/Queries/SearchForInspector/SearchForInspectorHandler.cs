using Adapters.Context;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Application.Wrappers;
using AutoMapper;
using Domain.Compacts.Settings.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.SearchForInspector
{
    internal class SearchForInspectorHandler : IRequestHandler<SearchForInspectorQuery,
        PagedResponse<IEnumerable<CompactInspectionDTO>>>
    {
        private readonly ICompactInspectionRepository _compactInspectionRepository;
        private readonly ISessionContext _sessionContext;
        private readonly IMapper _mapper;

        public SearchForInspectorHandler(
            ICompactInspectionRepository compactInspectionRepository,
            ISessionContext sessionContext,
            IMapper mapper)
        {
            _compactInspectionRepository = compactInspectionRepository;
            _sessionContext = sessionContext;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<CompactInspectionDTO>>> Handle(
            SearchForInspectorQuery query,
            CancellationToken cancellationToken)
        {
            var inspections = _compactInspectionRepository.SearchToDashboard(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy,
                _sessionContext.UserSession?.Id
            );

            return await inspections.Paginate<CompactInspection, CompactInspectionDTO>(query.Current, query.Limit,
                _mapper);
        }
    }
}