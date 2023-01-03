using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;

namespace Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues
{
    public interface IIssueRepository :
        IGetByIdRepository<Issue>,
        IInsertRepository<Issue>,
        IUpdateRepository<Issue>
    {
        IQueryable<Issue> SearchToDashboard(
            string? filter,
            string? tag,
            int current,
            int limit,
            string? orderDirection,
            string? orderBy
        );

        Task<Issue?> GetByIdWithTags(int id);

        Task<IEnumerable<Issue>?> GetByAnswerVersionId(int id);

        Task<IEnumerable<Issue>?> GetByRecommendationVersionId(int id);
    }
}
