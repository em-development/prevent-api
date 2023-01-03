using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public interface IInspectionPropertyCoverageRepository :
        IGetByIdRepository<InspectionPropertyCoverage>,
        IInsertRepository<InspectionPropertyCoverage>,
        IUpdateRepository<InspectionPropertyCoverage>,
        IRemoveRepository<InspectionPropertyCoverage>
    {
        Task<List<InspectionPropertyCoverage?>> GetByInspectionId(int inspectionId);
    }
}
