using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public interface IInspectionAnswerVersionRepository :
        IGetByIdRepository<InspectionAnswerVersion>,
        IInsertRepository<InspectionAnswerVersion>,
        IUpdateRepository<InspectionAnswerVersion>,
        IRemoveRepository<InspectionAnswerVersion>
    {
        Task<List<InspectionAnswerVersion?>> GetByInspectionAnswerId(int inspectionAnswerId);
    }
}
