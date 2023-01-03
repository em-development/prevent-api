using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations
{
    public interface IRecommendationAttachmentRepository :
        IGetByIdRepository<RecommendationAttachment>,
        IInsertRepository<RecommendationAttachment>,
        IUpdateRepository<RecommendationAttachment>
    {
        Task<List<RecommendationAttachment?>> GetByRecommendationVersionId(int id);
    }
}
