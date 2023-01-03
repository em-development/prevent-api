using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersionRepository : BaseRepository, IChecklistVersionRepository
    {
        public ChecklistVersionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ChecklistVersion>?> GetByChecklistId(int checklistId)
        {
            return await _dbContext.ChecklistVersions
                .Where(x => x.ChecklistId == checklistId)
                .ToListAsync();
        }

        public async Task<ChecklistVersion> InsertAsync(ChecklistVersion entity)
        {
            _dbContext.ChecklistVersions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(ChecklistVersion entity)
        {
            _dbContext.ChecklistVersions.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
