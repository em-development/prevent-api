using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.Checklist.RecommendationsCore.Issues
{
    public class Issue : Entity
    {
        public Description Description { get; private set; }
        public bool IsActive { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private Issue()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<IssueTag>? Tags { get; private set; }
        public virtual IEnumerable<AnswerVersionIssues>? AnswerVersionIssues { get; private set; }
        public virtual IEnumerable<RecommendationVersionIssue>? RecommendationVersionIssues { get; private set; }

        public Issue(string description, bool isActive)
        {
            Description = Description.CreateValid(description, this.GetType().Name);
            IsActive = isActive;
        }

        public object GetToLog()
        {
            return new
            {
                Description = Description,
                IsActive = IsActive
            };
        }

        public void Update(string description, bool isActive)
        {
            Description = Description.CreateValid(description, this.GetType().Name);
            IsActive = isActive;
        }

        public void SetDescription(string description)
        {
            Description = Description.CreateValid(description, this.GetType().Name);
        }
    }
}
