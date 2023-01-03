using Domain.Entities.Base;
using Domain.Entities.Inspections.InspectionAnswers;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswer : Entity
    {
        public int InspectionId { get; private set; }
        public int ChecklistVersionId { get; private set; }
        public int QuestionVersionId { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        public InspectionAnswer()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor

        public virtual Inspection? Inspection { get; private set; }
        public virtual ChecklistVersion? ChecklistVersion { get; private set; }
        public virtual QuestionVersion? QuestionVersion { get; private set; }
        public virtual IEnumerable<InspectionAnswerVersion>? InspectionAnswerVersions { get; private set; }
        public virtual IEnumerable<InspectionAnswerCustom>? InspectionAnswerCustoms { get; private set; }
        public virtual IEnumerable<InspectionAnswerAttachment>? InspectionAnswerAttachments { get; private set; }

        public InspectionAnswer(
            int inspectionId,
            int checklistVersionId,
            int questionVersionId
        )
        {
            InspectionId = inspectionId;
            ChecklistVersionId = checklistVersionId;
            QuestionVersionId = questionVersionId;
        }
    }
}