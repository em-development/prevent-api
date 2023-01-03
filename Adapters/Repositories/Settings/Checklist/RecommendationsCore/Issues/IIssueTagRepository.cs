using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;

namespace Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues
{
    public interface IIssueTagRepository :
        IInsertRepository<IssueTag>,
        IRemoveRepository<IssueTag>
    {

        Task<IssueTag?> GetByTag(string tag);
    }
}
