using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Commands.CreateInspectionTemplate
{
    public class CreateInspectionTemplateRequest : InspectionTemplateFormDTO, IRequest<Response<InspectionTemplateFormDTO>>
    {
    }
}
