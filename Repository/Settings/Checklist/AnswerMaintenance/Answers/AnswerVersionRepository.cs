using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerVersionRepository : BaseRepository, IAnswerVersionRepository
    {
        public AnswerVersionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<AnswerVersion>?> GetByAnswerId(int answerId)
        {
            return await _dbContext.AnswerVersions
                .Where(x => x.AnswerId == answerId)
                .ToListAsync();
        }

        public async Task<AnswerVersion> InsertAsync(AnswerVersion entity)
        {
            this._dbContext.AnswerVersions.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(AnswerVersion entity)
        {
            this._dbContext.AnswerVersions.Remove(entity);

            await this._dbContext.SaveChangesAsync();
        }
    }
}
