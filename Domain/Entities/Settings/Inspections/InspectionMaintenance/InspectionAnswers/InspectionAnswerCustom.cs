using Domain.Entities.Base;
using Domain.ValueObjects.Settings.Inspections;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswerCustom : Entity
    {
        public int InspectionAnswerId { get; private set; }
        public InspectionAnswerCustomAnswer Answer { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public InspectionAnswerCustom()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual InspectionAnswer? InspectionAnswer { get; private set; }

        public InspectionAnswerCustom(
            int inspectionAnswerId,
            string inspectionAnswerCustomAnswer
            )
        {
            InspectionAnswerId = inspectionAnswerId;
            Answer = InspectionAnswerCustomAnswer.CreateValid(inspectionAnswerCustomAnswer, this.GetType().Name);
        }
    }
}
