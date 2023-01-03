using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetById
{
    public class GetByIdQuery : FilterParams, IRequest<Response<CompactInspectionDTO?>>
    {
        public int Id { get; set; }
    }
}