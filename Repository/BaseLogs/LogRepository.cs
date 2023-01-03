using Adapters.Repositories.BaseLogs;
using Domain.Entities.BaseLogs;
using Domain.Identifiers.BaseLogs;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace CC.Repository.BaseLogs
{
    public class LogRepository : BaseRepository, ILogRepository
    {
        public LogRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Log>?> GetAllAsync()
        {
            return await _dbContext.Logs.ToListAsync();
        }

        public async Task<Log?> GetByIdAsync(int id)
        {
            return await _dbContext.Logs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Log> InsertAsync(Log log)
        {
            _dbContext.Logs.Add(log);

            await _dbContext.SaveChangesAsync();

            return log;
        }

        public async Task<Log?> GetLastSpecificLog(
            string source,
            string owner)
        {
            return await _dbContext.Logs
                .AsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(x => x.Source == source
                            && x.Owner == owner);
        }


        public async Task<Log?> GetLastSpecificLog(
            string source,
            string owner,
            string action)
        {
            return await _dbContext.Logs
                .AsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(x => x.Source == source
                            && x.Owner == owner
                            && x.Action == action);
        }

        public async Task<Log?> GetLastSpecificLog(
            string source,
            string owner,
            string action,
            string? reference = null)
        {
            return await _dbContext.Logs
                .AsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(x => x.Source == source
                            && x.Owner == owner
                            && x.Reference == reference
                            && x.Action == action);
        }

        public async Task<IEnumerable<Log?>> GetByRecommendationId(int recommendationId)
        {
            return _dbContext.Logs
                .AsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.Date)
                .Where(x => 
                    x.Source == LogSouceType.SETTINGS_RECOMMENDATION.Value && 
                    x.Reference == recommendationId.ToString());
        }

        public async Task<IEnumerable<Log?>> GetByInspectionId(int inspectionId)
        {
            return _dbContext.Logs
                .AsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.Date)
                .Where(x =>
                    x.Source == LogSouceType.SETTINGS_INSPECTIONS.Value &&
                    x.Owner == inspectionId.ToString());
        }
    }
}