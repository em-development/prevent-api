using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.RecommendationsCore.Issues
{
    public class IssueTagRepository : BaseRepository, IIssueTagRepository
    {
        public IssueTagRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IssueTag?> GetByTag(string tag)
        {
            return await _dbContext.IssueTags
                .FirstOrDefaultAsync(x => x.Tag.Value == tag);
        }

        public async Task<IssueTag> InsertAsync(IssueTag entity)
        {
            this._dbContext.IssueTags.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(IssueTag entity)
        {
            this._dbContext.IssueTags.Remove(entity);

            await this._dbContext.SaveChangesAsync();
        }
    }
}
