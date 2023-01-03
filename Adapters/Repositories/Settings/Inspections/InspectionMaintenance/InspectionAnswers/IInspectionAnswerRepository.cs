using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public interface IInspectionAnswerRepository :
        IGetByIdRepository<InspectionAnswer>,
        IInsertRepository<InspectionAnswer>,
        IUpdateRepository<InspectionAnswer>,
        IRemoveRepository<InspectionAnswer>
    {
        Task<List<InspectionAnswer?>> GetByInspectionId(int inspectionId);
    }
}
