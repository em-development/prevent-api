using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;

namespace Adapters.Repositories.Settings.Checklist.ChecklistMaintenance
{
    public interface IChecklistVersionQuestionsRepository :
        IInsertRepository<ChecklistVersionQuestions>,
        IRemoveRepository<ChecklistVersionQuestions>
    {
        Task<List<ChecklistVersionQuestions?>> GetByChecklistVersionId(int checklistVersionId);
    }
}
