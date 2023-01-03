using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;

namespace Adapters.Repositories.Settings.Checklist.ChecklistMaintenance
{
    public interface IChecklistVersionRepository :
        IInsertRepository<ChecklistVersion>,
        IRemoveRepository<ChecklistVersion>
    {
        Task<IEnumerable<ChecklistVersion>?> GetByChecklistId(int checklistId);
    }
}
