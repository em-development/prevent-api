using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.ValueObjects.Settings.Checklist.QuestionsMaintenance.Questions;
using Domain.ValueObjects.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Domain.Entities.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersion : Entity
    {
        public int ChecklistId { get; private set; }
        public Title Title { get; private set; }
        public Key Key { get; private set; }
        public int Version { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private ChecklistVersion()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Checklist? Checklist { get; private set; }
        public virtual IEnumerable<ChecklistVersionQuestions>? ChecklistVersionQuestions { get; private set; }
        public virtual IEnumerable<InspectionAnswer>? InspectionAnswers { get; private set; }

        public ChecklistVersion(
            int checklistId,
            string title,
            string key,
            int version
        )
        {
            ChecklistId = checklistId;
            Title = Title.CreateValid(title, GetType().Name);
            Key = Key.CreateValid(key, GetType().Name);
            Version = version;
        }

        public void IncrementVersion(int currentVersion)
        {
            Version = currentVersion + 1;
        }

        public void SetTitle(string title)
        {
            Title = Title.CreateValid(title, GetType().Name);
        }
    }
}
