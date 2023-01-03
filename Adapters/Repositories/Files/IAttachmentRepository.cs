using Adapters.Repositories.Base;
using Domain.Entities.Files;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace Adapters.Repositories.Files
{
    public interface IAttachmentRepository :
        IGetByIdRepository<Attachment>,
        IInsertRepository<Attachment>,
        IUpdateRepository<Attachment>
    {

    }
}
