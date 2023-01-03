using Adapters.Repositories.Base;
using Domain.Entities.BaseLogs;

namespace Adapters.Repositories.BaseLogs
{
    public interface ILogRepository : IGetAllRepository<Log>,
    IGetByIdRepository<Log>,
    IInsertRepository<Log>
    {
        Task<Log?> GetLastSpecificLog(string source, string owner);
        Task<Log?> GetLastSpecificLog(string source, string owner, string action);
        Task<Log?> GetLastSpecificLog(string source, string owner, string action, string reference);
        Task<IEnumerable<Log?>> GetByRecommendationId(int recommendationId);
        Task<IEnumerable<Log?>> GetByInspectionId(int inspectionId);
    }
}

