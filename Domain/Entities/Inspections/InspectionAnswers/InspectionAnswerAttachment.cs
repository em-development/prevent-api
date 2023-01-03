using Domain.Entities.Base;
using Domain.Entities.Inspections.Inspections;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;

namespace Domain.Entities.Inspections.InspectionAnswers;

public class InspectionAnswerAttachment : Entity
{
    public int InspectionAttachmentId { get; private set; }
    public int InspectionAnswerId { get; private set; }

    #region EF Constructor

#pragma warning disable CS8618
    public InspectionAnswerAttachment()
    {
    }
#pragma warning restore CS8618

    #endregion EF Constructor

    public virtual InspectionAttachment? InspectionAttachment { get; private set; }
    public virtual InspectionAnswer? InspectionAnswer { get; private set; }

    public InspectionAnswerAttachment(int inspectionAttachmentId, int inspectionAnswerId)
    {
        InspectionAttachmentId = inspectionAttachmentId;
        InspectionAnswerId = inspectionAnswerId;
    }
}