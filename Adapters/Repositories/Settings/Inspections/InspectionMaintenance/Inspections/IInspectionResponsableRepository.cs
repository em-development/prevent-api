using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections
{
    public interface IInspectionResponsableRepository :
        IGetByIdRepository<InspectionResponsable>,
        IInsertRepository<InspectionResponsable>,
        IUpdateRepository<InspectionResponsable>,
        IRemoveRepository<InspectionResponsable>
    {
        Task<List<InspectionResponsable?>> GetByInspectionId(int inspectionId);
    }
}
