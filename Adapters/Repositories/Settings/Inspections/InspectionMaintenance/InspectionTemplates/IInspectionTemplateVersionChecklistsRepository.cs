using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public interface IInspectionTemplateVersionChecklistsRepository :
        IInsertRepository<InspectionTemplateVersionChecklists>,
        IRemoveRepository<InspectionTemplateVersionChecklists>
    {
        Task<List<InspectionTemplateVersionChecklists?>> GetByInspectionTemplateVersionId(int inspectionTemplateId);
    }
}
