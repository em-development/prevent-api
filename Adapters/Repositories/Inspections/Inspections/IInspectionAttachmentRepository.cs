using Adapters.Repositories.Base;
using Domain.Entities.Inspections.Inspections;

namespace Adapters.Repositories.Inspections.Inspections;

public interface IInspectionAttachmentRepository :
    IGetByIdRepository<InspectionAttachment>,
    IInsertRepository<InspectionAttachment>,
    IRemoveRepository<InspectionAttachment>
{
    Task<IEnumerable<InspectionAttachment>> ListByInspectionId(int inspectionId);
}