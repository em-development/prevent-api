using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.ScheduleInspection
{
    public class ScheduleInspectionRequest : InspectionDTO, IRequest<Response<InspectionDTO>>
    {
    }
}

