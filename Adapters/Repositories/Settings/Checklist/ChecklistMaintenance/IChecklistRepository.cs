using Adapters.Repositories.Base;
using DomainChecklistMaintenance = Domain.Entities.Settings.Checklist.ChecklistMaintenance;

namespace Adapters.Repositories.Settings.Checklist.ChecklistMaintenance
{
    public interface IChecklistRepository :
        IGetByIdRepository<DomainChecklistMaintenance.Checklist>,
        IInsertRepository<DomainChecklistMaintenance.Checklist>,
        IUpdateRepository<DomainChecklistMaintenance.Checklist>
    {
        IQueryable<DomainChecklistMaintenance.Checklist> SearchToDashboard(
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<DomainChecklistMaintenance.Checklist> SearchToSideForm(
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        Task<DomainChecklistMaintenance.Checklist?> GetByIdWithVersions(int id);

        Task<IEnumerable<DomainChecklistMaintenance.Checklist>?> GetByInspectionTemplateVersionId(int id);
        Task<IEnumerable<DomainChecklistMaintenance.Checklist>?> GetByInspectionTemplateVersionIdToAnswer(int id, int inspectionId);
    }
}