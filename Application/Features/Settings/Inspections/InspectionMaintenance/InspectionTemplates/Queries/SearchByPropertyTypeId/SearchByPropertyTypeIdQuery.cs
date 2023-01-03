using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.SearchByPropertyTypeId
{
    public class SearchByPropertyTypeIdQuery : FilterParams, IRequest<PagedResponse<IEnumerable<InspectionTemplateFormDTO>>>
    {
        public string Filter { get; set; } = string.Empty;
        public int PropertyTypeId { get; set; }
    }
}