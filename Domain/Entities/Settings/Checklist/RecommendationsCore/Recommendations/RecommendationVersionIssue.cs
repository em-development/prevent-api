using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;

namespace Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionIssue : Entity
    {
        public int RecommendationVersionId { get; private set; }
        public int IssueId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public RecommendationVersionIssue()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual RecommendationVersion? RecommendationVersion { get; private set; }
        public virtual Issue? Issue { get; private set; }

        public RecommendationVersionIssue(int recommendationVersionId, int issueId)
        {
            RecommendationVersionId = recommendationVersionId;
            IssueId = issueId;
        }

        public void SetRecommendationVersionId(int recommendationVersionId)
        {
            this.RecommendationVersionId = recommendationVersionId;
        }
    }
}
