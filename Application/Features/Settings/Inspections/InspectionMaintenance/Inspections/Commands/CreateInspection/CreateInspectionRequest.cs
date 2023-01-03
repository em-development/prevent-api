using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.CreateInspection
{
    public class CreateInspectionRequest : InspectionDTO, IRequest<Response<InspectionDTO>>
    {
    }
}
