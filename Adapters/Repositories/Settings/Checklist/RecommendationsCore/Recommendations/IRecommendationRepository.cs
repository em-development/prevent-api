using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations
{
    public interface IRecommendationRepository :
        IGetByIdRepository<Recommendation>,
        IInsertRepository<Recommendation>,
        IUpdateRepository<Recommendation>
    {
        IQueryable<Recommendation> SearchToDashboard(
            int status,
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<Recommendation> SearchToSideForm(
            int status,
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        Task<Recommendation?> GetByIdWithVersions(int id);
    }
}
