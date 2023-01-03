using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.GetById;

public class GetByIdToFormQuery : IRequest<Response<ChecklistFormDTO>>
{
    public int Id { get; set; }
}
