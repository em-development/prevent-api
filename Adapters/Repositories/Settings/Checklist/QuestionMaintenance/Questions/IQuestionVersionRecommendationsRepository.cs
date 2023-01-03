using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions
{
    public interface IQuestionVersionRecommendationsRepository :
        IInsertRepository<QuestionVersionRecommendations>,
        IRemoveRepository<QuestionVersionRecommendations>
    {
        Task<List<QuestionVersionRecommendations?>> GetByQuestionVersionId(int questionVersionId);
    }
}
