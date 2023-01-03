using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersion : Entity
    {
        public int RecommendationId { get; private set; }
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public DueDateText DueDateText { get; private set; }
        public int RecommendationVersionStatusId { get; private set; }
        public int Version { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private RecommendationVersion()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Recommendation? Recommendation { get; private set; }
        public virtual IEnumerable<RecommendationVersionIssue>? RecommendationVersionIssues { get; private set; }
        public virtual IEnumerable<RecommendationAttachment>? RecommendationAttachments { get; private set; }
        public virtual RecommendationVersionStatus? RecommendationVersionStatus { get; private set; }
        public virtual IEnumerable<QuestionVersionRecommendations>? QuestionVersionRecommendations { get; private set; }

        public RecommendationVersion(int recommendationId, string title, string description, string dueDateText, RecommendationVersionStatusEnum statusEnum, int version)
        {
            RecommendationId = recommendationId;
            Description = Description.CreateValid(description, GetType().Name);
            DueDateText = DueDateText.CreateValid(dueDateText, GetType().Name);
            Title = Title.CreateValid(title, GetType().Name);
            Version = version;
            RecommendationVersionStatusId = (int)statusEnum;
        }

        public void IncrementVersion(int currentVersion)
        {
            Version = currentVersion + 1;
        }

        public void SetDescription(string description)
        {
            Description = Description.CreateValid(description, GetType().Name);
        }

        public void SetStatusApprove()
        {
            RecommendationVersionStatusId = (int)RecommendationVersionStatusEnum.APPROVED;
        }

        public void SetStatusDisapprove()
        {
            RecommendationVersionStatusId = (int)RecommendationVersionStatusEnum.PENDING;
        }
    }
}
