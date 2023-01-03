using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Commands.CreateChecklist
{
    public class CreateChecklistRequest : ChecklistFormDTO, IRequest<Response<ChecklistFormDTO>>
    {
    }
}
