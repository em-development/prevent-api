using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers
{
    public class Answer : Entity
    {
        public int? VersionId { get; private set; }
        public bool IsActive { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public Answer()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual AnswerVersion? Version { get; private set; }
        public virtual IEnumerable<AnswerVersion>? AnswerVersions { get; private set; }

        public Answer(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetVersion(int versionId)
        {
            this.VersionId = versionId;
        }

        public void SetVersion(AnswerVersion answerVersion)
        {
            this.Version = answerVersion;
        }
    }
}
