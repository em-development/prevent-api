using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers
{
    public interface IAnswerVersionRepository :
        IInsertRepository<AnswerVersion>,
        IRemoveRepository<AnswerVersion>
    {
        Task<IEnumerable<AnswerVersion>?> GetByAnswerId(int answerId);
    }
}
