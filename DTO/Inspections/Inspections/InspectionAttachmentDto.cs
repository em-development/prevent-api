using DTO.Files;

namespace DTO.Inspections.Inspections;

public class InspectionAttachmentDto
{
    public int Id { get; set; }
    public AttachmentDto Attachment { get; set; } = null!;
}