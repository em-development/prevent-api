using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerVersion : Entity
    {
        public int AnswerId { get; private set; }
        public Description Description { get; private set; }
        public int Version { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private AnswerVersion()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Answer? Answer { get; private set; }
        public virtual IEnumerable<AnswerVersionIssues>? AnswerVersionIssues { get; private set; }
        public virtual IEnumerable<QuestionVersionAnswers>? QuestionVersionAnswers { get; private set; }
        public virtual IEnumerable<InspectionAnswerVersion>? InspectionAnswerVersions { get; private set; }

        public AnswerVersion(int answerId, string description, int version)
        {
            AnswerId = answerId;
            Description = Description.CreateValid(description, this.GetType().Name);
            Version = version;
        }

        public void IncrementVersion(int currentVersion)
        {
            Version = currentVersion + 1;
        }

        public void SetDescription(string description)
        {
            Description = Description.CreateValid(description, this.GetType().Name);
        }
    }
}
