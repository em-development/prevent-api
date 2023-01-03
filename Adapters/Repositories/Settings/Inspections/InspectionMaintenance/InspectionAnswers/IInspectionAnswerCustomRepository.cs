using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public interface IInspectionAnswerCustomRepository :
        IGetByIdRepository<InspectionAnswerCustom>,
        IInsertRepository<InspectionAnswerCustom>,
        IUpdateRepository<InspectionAnswerCustom>,
        IRemoveRepository<InspectionAnswerCustom>
    {
        Task<List<InspectionAnswerCustom?>> GetByInspectionAnswerId(int inspectionAnswerId);
    }
}
