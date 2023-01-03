using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswerVersion : Entity
    {
        public int InspectionAnswerId { get; private set; }
        public int AnswerVersionId { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        public InspectionAnswerVersion()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor

        public virtual InspectionAnswer? InspectionAnswer { get; private set; }
        public virtual AnswerVersion? AnswerVersion { get; private set; }

        public InspectionAnswerVersion(int inspectionAnswerId, int answerVersionId)
        {
            InspectionAnswerId = inspectionAnswerId;
            AnswerVersionId = answerVersionId;
        }
    }
}