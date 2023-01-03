using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public interface IInspectionTemplateVersionRepository :
        IInsertRepository<InspectionTemplateVersion>,
        IRemoveRepository<InspectionTemplateVersion>
    {
        Task<IEnumerable<InspectionTemplateVersion>?> GetByInspectionTemplateId(int inspectionTemplateId);
        Task<InspectionTemplateVersion?> GetByIdWithChecklistsAndQuestions(int id);
    }
}
