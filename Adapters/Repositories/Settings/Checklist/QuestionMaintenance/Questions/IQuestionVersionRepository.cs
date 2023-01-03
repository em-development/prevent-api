using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions
{
    public interface IQuestionVersionRepository :
        IInsertRepository<QuestionVersion>,
        IRemoveRepository<QuestionVersion>
    {
        Task<IEnumerable<QuestionVersion>?> GetByQuestionId(int questionId);
    }
}
