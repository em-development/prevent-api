using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.GetByIdToForm
{
    public class GetByIdToFormQuery : IRequest<Response<InspectionTemplateFormDTO>>
    {
        public int Id { get; set; }
    }
}
