using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.RecommendationsCore.Issues
{
    public class IssueRepository : BaseRepository, IIssueRepository
    {
        public IssueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Issue?> GetByIdAsync(int id)
        {
            return await _dbContext.Issues
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Issue> SearchToDashboard(
            string? filter = null,
            string? tag = null,
            int current = 0,
            int limit = 25,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<Issue> query = _dbContext.Issues.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(i => i.Description.Value.Contains(filter));
            }

            if (!string.IsNullOrEmpty(tag))
            {
                query = query.Where(i => i.Tags != null
                                        && i.Tags.Any(t => t.Tag.Value.Contains(tag)));
            }

            if (!string.IsNullOrEmpty(orderDirection) && orderDirection == "asc")
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "description")
                {
                    query = query.OrderBy(i => i.Description.Value);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "description")
                {
                    query = query.OrderByDescending(i => i.Description.Value);
                }
            }

            return query.Include(x => x.Tags);
        }

        public async Task<Issue?> GetByIdWithTags(int id)
        {
            return await _dbContext.Issues
                .Include(i => i.Tags)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Issue>?> GetByAnswerVersionId(int id)
        {
            return await _dbContext.AnswerVersionIssues
                .Where(x => x.AnswerVersion.Id == id)
                .Include(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Select(x => x.Issue)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Issue>?> GetByRecommendationVersionId(int id)
        {
            return await _dbContext.RecommendationVersionIssues
                .Where(x => x.RecommendationVersion.Id == id)
                .Include(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Select(x => x.Issue)
                .ToArrayAsync();
        }

        public async Task<Issue> InsertAsync(Issue entity)
        {
            this._dbContext.Issues.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Issue> UpdateAsync(Issue entity)
        {
            this._dbContext.Issues.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
