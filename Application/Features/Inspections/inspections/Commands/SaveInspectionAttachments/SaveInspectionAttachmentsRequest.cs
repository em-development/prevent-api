using Application.Wrappers;
using DTO.Files;
using DTO.Inspections.Inspections;
using MediatR;

namespace Application.Features.Inspections.inspections.Commands.SaveInspectionAttachments
{
    public class SaveInspectionAttachmentsRequest : IRequest<Response<IEnumerable<InspectionAttachmentDto>>>
    {
        public int InspectionId { get; set; }
        public IEnumerable<AttachmentDto> Attachments { get; set; } = null!;
    }
}