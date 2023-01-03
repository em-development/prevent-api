using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations
{
    public interface IRecommendationVersionRepository :
        IGetByIdRepository<RecommendationVersion>,
        IInsertRepository<RecommendationVersion>,
        IRemoveRepository<RecommendationVersion>
    {
        Task<IEnumerable<RecommendationVersion>?> GetByRecommendationId(int recommendationId);
        Task<RecommendationVersion?> Approve(RecommendationVersion recommendation);
        Task<RecommendationVersion?> Disapprove(RecommendationVersion recommendation);
    }
}