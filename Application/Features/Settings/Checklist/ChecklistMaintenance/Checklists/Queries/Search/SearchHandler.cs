using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<ChecklistDTO>>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            IChecklistRepository checklistRepository,
            IMapper mapper
            )
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ChecklistDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist> checklists = _checklistRepository.SearchToDashboard(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await checklists.Paginate<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist, ChecklistDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
