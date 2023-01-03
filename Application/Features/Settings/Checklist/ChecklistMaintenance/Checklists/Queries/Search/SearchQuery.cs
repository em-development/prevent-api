using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.Search
{
    public class SearchQuery : FilterParams, IRequest<PagedResponse<IEnumerable<ChecklistDTO>>>
    {
        public string? Filter { get; set; }
    }
}