using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public interface IInspectionTemplateVersionPropertyTypesRepository :
        IInsertRepository<InspectionTemplateVersionPropertyTypes>,
        IRemoveRepository<InspectionTemplateVersionPropertyTypes>
    {
        Task<List<InspectionTemplateVersionPropertyTypes?>> GetByInspectionTemplateVersionId(int inspectionTemplateId);
    }
}
