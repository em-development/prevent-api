using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetByIdToForm
{
    public class GetByIdToFormQuery : IRequest<Response<InspectionFormDTO>>
    {
        public int Id { get; set; }
    }
}
