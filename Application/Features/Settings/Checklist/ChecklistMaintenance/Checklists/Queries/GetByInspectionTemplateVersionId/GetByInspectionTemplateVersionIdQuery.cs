using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.GetByInspectionTemplateVersionId
{
    public class GetByInspectionTemplateVersionIdQuery : IRequest<Response<IEnumerable<ChecklistDTO>>>
    {
        public int Id { get; set; }
    }
}