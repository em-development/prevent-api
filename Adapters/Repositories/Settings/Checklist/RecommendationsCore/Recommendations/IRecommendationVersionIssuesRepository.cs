using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations
{
    public interface IRecommendationVersionIssuesRepository :
        IInsertRepository<RecommendationVersionIssue>,
        IRemoveRepository<RecommendationVersionIssue>
    {
        Task<List<RecommendationVersionIssue?>> GetByRecommendationVersionId(int recommendationVersionId);
    }
}
