using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class Recommendation : Entity
    {
        public int? VersionId { get; private set; }
        public bool IsActive { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public Recommendation()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual RecommendationVersion? Version { get; private set; }
        public virtual IEnumerable<RecommendationVersion>? RecommendationVersions { get; private set; }

        public Recommendation(bool isActive)
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

        public void SetVersion(RecommendationVersion recommendationVersion)
        {
            this.Version = recommendationVersion;
        }
    }
}
