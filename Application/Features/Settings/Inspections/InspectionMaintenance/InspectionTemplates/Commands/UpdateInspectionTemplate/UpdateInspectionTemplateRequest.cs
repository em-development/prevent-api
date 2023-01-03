using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Commands.UpdateInspectionTemplate
{
    public class UpdateInspectionTemplateRequest : InspectionTemplateFormDTO, IRequest<Response<InspectionTemplateFormDTO>>
    {
    }
}

