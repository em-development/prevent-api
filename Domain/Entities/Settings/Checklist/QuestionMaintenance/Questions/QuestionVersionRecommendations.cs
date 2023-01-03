using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Domain.Entities.Settings.Checklist.QuestionMaintenance
{
    public class QuestionVersionRecommendations : Entity
    {
        public int QuestionVersionId { get; private set; }
        public int RecommendationVersionId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private QuestionVersionRecommendations()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual QuestionVersion? QuestionVersion { get; private set; }
        public virtual RecommendationVersion? RecommendationVersion { get; private set; }

        public QuestionVersionRecommendations(int questionVersionId, int recommendationVersionId)
        {
            QuestionVersionId = questionVersionId;
            RecommendationVersionId = recommendationVersionId;
        }
    }
}
