using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerVersionIssuesRepository : BaseRepository, IAnswerVersionIssuesRepository
    {
        public AnswerVersionIssuesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<AnswerVersionIssues?>> GetByAnswerVersionId(int answerVersionId)
        {
            return await _dbContext.AnswerVersionIssues
                .Where(x => x.AnswerVersionId == answerVersionId)
                .ToListAsync();
        }

        public async Task<AnswerVersionIssues> InsertAsync(AnswerVersionIssues entity)
        {
            this._dbContext.AnswerVersionIssues.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(AnswerVersionIssues entity)
        {
            this._dbContext.AnswerVersionIssues.Remove(entity);

            await this._dbContext.SaveChangesAsync();
        }
    }
}
