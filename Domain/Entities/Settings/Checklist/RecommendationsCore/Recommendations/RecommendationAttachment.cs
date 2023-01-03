using Domain.Entities.Base;
using Domain.Entities.Files;

namespace Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationAttachment : Entity
    {
        public int RecommendationVersionId { get; private set; }
        public int AttachmentId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public RecommendationAttachment()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor
        
        public virtual Attachment? Attachment { get; private set; }
        public virtual RecommendationVersion? RecommendationVersion { get; private set; }

        public RecommendationAttachment(int attachmentId, int recommendationVersionId)
        {
            AttachmentId = attachmentId;
            RecommendationVersionId = recommendationVersionId;
        }
        public void SetAttachmentId(int attachmentId)
        {
            this.AttachmentId = attachmentId;
        }

        public void SetRecommendationVersionId(int recommendationVersionId)
        {
            this.RecommendationVersionId = recommendationVersionId;
        }
    }
}
