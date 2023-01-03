using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.SearchSideForm
{
    internal class SearchSideFormHandler : IRequestHandler<SearchSideFormQuery, PagedResponse<IEnumerable<ChecklistFormDTO>>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public SearchSideFormHandler(
            IChecklistRepository checklistRepository,
            IMapper mapper
            )
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ChecklistFormDTO>>> Handle(
            SearchSideFormQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist> checklists = _checklistRepository.SearchToSideForm(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await checklists.Paginate<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist, ChecklistFormDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
