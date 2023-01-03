using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.
    GetByInspectionTemplateVersionIdToAnswer
{
    public class GetByInspectionTemplateVersionIdToAnswerQuery : IRequest<Response<IEnumerable<ChecklistDTO>>>
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
    }
}