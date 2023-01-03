using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;

namespace Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerVersionIssues : Entity
    {
        public int AnswerVersionId { get; private set; }
        public int IssueId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private AnswerVersionIssues()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual AnswerVersion? AnswerVersion { get; private set; }
        public virtual Issue? Issue { get; private set; }

        public AnswerVersionIssues(int answerVersionId, int issueId)
        {
            AnswerVersionId = answerVersionId;
            IssueId = issueId;
        }
    }
}
