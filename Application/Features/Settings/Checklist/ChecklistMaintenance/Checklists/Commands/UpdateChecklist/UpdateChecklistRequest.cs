using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Commands.UpdateChecklist
{
    public class UpdateChecklistRequest : ChecklistFormDTO, IRequest<Response<ChecklistFormDTO>>
    {
    }
}

