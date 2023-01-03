using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions
{
    public interface ISubQuestionVersionsRepository :
        IInsertRepository<SubQuestionVersions>,
        IRemoveRepository<SubQuestionVersions>
    {
        Task<List<SubQuestionVersions?>> GetByQuestionVersionId(int questionVersionId);
    }
}
