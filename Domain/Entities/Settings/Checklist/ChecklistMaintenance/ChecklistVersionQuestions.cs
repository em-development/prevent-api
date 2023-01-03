using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Domain.Entities.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersionQuestions : Entity
    {
        public int ChecklistVersionId { get; private set; }
        public int QuestionId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private ChecklistVersionQuestions()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual ChecklistVersion? ChecklistVersion { get; private set; }
        public virtual Question? Question { get; private set; }

        public ChecklistVersionQuestions(int checklistVersionId, int questionId)
        {
            ChecklistVersionId = checklistVersionId;
            QuestionId = questionId;
        }
    }
}
