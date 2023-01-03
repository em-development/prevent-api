using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplateVersions.Queries.GetByInspectionTemplateId
{
    public class GetByInspectionTemplateIdQuery : IRequest<Response<IEnumerable<InspectionTemplateVersionDTO>>>
    {
        public int Id { get; set; }
    }
}