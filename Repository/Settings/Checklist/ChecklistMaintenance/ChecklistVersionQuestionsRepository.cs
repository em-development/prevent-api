using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersionQuestionsRepository : BaseRepository, IChecklistVersionQuestionsRepository
    {
        public ChecklistVersionQuestionsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ChecklistVersionQuestions?>> GetByChecklistVersionId(int checklistVersionId)
        {
            return await _dbContext.ChecklistVersionQuestions
                .Where(x => x.ChecklistVersionId == checklistVersionId)
                .ToListAsync();
        }

        public async Task<ChecklistVersionQuestions> InsertAsync(ChecklistVersionQuestions entity)
        {
            _dbContext.ChecklistVersionQuestions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(ChecklistVersionQuestions entity)
        {
            _dbContext.ChecklistVersionQuestions.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
