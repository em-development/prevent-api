using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.SearchSideForm
{
    public class SearchSideFormQuery : FilterParams, IRequest<PagedResponse<IEnumerable<ChecklistFormDTO>>>
    {
        public string? Filter { get; set; }
    }
}