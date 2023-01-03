using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers
{
    public interface IAnswerVersionIssuesRepository :
        IInsertRepository<AnswerVersionIssues>,
        IRemoveRepository<AnswerVersionIssues>
    {
        Task<List<AnswerVersionIssues?>> GetByAnswerVersionId(int answerVersionId);
    }
}
