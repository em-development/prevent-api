using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;

namespace Domain.Entities.Settings.Checklist.QuestionMaintenance
{
    public class Question : Entity
    {
        public int? VersionId { get; private set; }
        public bool IsActive { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public Question()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual QuestionVersion? Version { get; private set; }
        public virtual IEnumerable<QuestionVersion>? QuestionVersions { get; private set; }
        public virtual IEnumerable<ChecklistVersionQuestions>? ChecklistVersionQuestions { get; private set; }

        public Question(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetVersion(int versionId)
        {
            VersionId = versionId;
        }

        public void SetVersion(QuestionVersion questionVersion)
        {
            Version = questionVersion;
        }
    }
}
