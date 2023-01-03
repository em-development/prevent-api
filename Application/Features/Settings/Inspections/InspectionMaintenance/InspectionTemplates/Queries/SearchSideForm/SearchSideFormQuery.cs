using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.SearchSideForm
{
    public class SearchSideFormQuery : FilterParams, IRequest<PagedResponse<IEnumerable<InspectionTemplateFormDTO>>>
    {
        public string? Filter { get; set; }
    }
}