using Domain.Entities.Base;
using Domain.Entities.Files;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Domain.Entities.Inspections.Inspections;

public class InspectionAttachment : Entity
{
    public int AttachmentId { get; private set; }
    public int InspectionId { get; private set; }

    #region EF Constructor

#pragma warning disable CS8618
    public InspectionAttachment()
    {
    }
#pragma warning restore CS8618

    #endregion EF Constructor

    public virtual Attachment? Attachment { get; private set; }
    public virtual Inspection? Inspection { get; private set; }

    public InspectionAttachment(int attachmentId, int inspectionId)
    {
        AttachmentId = attachmentId;
        InspectionId = inspectionId;
    }
}