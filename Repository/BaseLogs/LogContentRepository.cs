using Adapters.Repositories.BaseLogs;
using Domain.Entities.BaseLogs;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.BaseLogs
{
    public class LogContentRepository : BaseRepository, ILogContentRepository
    {
        public LogContentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LogContent?> GetByIdAsync(int id)
        {
            return await _dbContext.LogContents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LogContent> InsertAsync(LogContent entity)
        {
            _dbContext.LogContents.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}