using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions
{
    public interface IQuestionVersionAnswersRepository :
        IInsertRepository<QuestionVersionAnswers>,
        IRemoveRepository<QuestionVersionAnswers>
    {
        Task<List<QuestionVersionAnswers?>> GetByQuestionVersionId(int questionVersionId);
    }
}
