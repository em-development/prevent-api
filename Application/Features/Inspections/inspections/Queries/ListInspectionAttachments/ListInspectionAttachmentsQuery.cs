using Application.Wrappers;
using DTO.Inspections.Inspections;
using MediatR;

namespace Application.Features.Inspections.inspections.Queries.ListInspectionAttachments
{
    public class ListInspectionAttachmentsQuery : IRequest<Response<IEnumerable<InspectionAttachmentDto>>>
    {
        public int InspectionId { get; set; }
    }
}