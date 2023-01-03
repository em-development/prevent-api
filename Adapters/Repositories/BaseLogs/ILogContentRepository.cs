using Adapters.Repositories.Base;
using Domain.Entities.BaseLogs;

namespace Adapters.Repositories.BaseLogs
{
    public interface ILogContentRepository : IGetByIdRepository<LogContent>,
    IInsertRepository<LogContent>
    {
    }
}

