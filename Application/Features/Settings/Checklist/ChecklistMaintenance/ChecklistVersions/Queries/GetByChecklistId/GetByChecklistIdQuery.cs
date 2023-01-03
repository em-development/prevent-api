using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.ChecklistVersions.Queries.GetByChecklistId
{
    public class GetByChecklistIdQuery : IRequest<Response<IEnumerable<ChecklistVersionDTO>>>
    {
        public int Id { get; set; }
    }
}