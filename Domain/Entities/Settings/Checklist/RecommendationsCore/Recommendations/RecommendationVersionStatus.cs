using Domain.Entities.Base;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionStatus : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private RecommendationVersionStatus()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<RecommendationVersion>? RecommendationVersions { get; private set; }

        public RecommendationVersionStatus(RecommendationVersionStatusEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(RecommendationVersionStatusEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}