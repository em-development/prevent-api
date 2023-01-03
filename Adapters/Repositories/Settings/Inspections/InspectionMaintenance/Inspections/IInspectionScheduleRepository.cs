using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections
{
    public interface IInspectionScheduleRepository :
        IGetByIdRepository<InspectionSchedule>,
        IInsertRepository<InspectionSchedule>,
        IUpdateRepository<InspectionSchedule>
    {

    }
}
