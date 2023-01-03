using Application.Wrappers;
using DTO.BaseLogs;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetLogsByInspectionId
{
    public class GetLogsByInspectionIdQuery : IRequest<Response<IEnumerable<LogDTO>?>>
    {
        public int Id { get; set; }
    }
}