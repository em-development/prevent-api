using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.SearchForInspector
{
    public class SearchForInspectorQuery : FilterParams, IRequest<PagedResponse<IEnumerable<CompactInspectionDTO>>>
    {
        public string? Filter { get; set; }
    }
}