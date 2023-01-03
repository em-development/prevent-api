using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public interface IInspectionPropertyBuildingRepository :
        IGetByIdRepository<InspectionPropertyBuilding>,
        IInsertRepository<InspectionPropertyBuilding>,
        IUpdateRepository<InspectionPropertyBuilding>,
        IRemoveRepository<InspectionPropertyBuilding>
    {
        Task<List<InspectionPropertyBuilding?>> GetByInspectionId(int inspectionId);
    }
}
