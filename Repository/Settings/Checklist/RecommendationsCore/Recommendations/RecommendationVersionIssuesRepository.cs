using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionIssuesRepository : BaseRepository, IRecommendationVersionIssuesRepository
    {
        public RecommendationVersionIssuesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<RecommendationVersionIssue?>> GetByRecommendationVersionId(int recommendationVersionId)
        {
            return await _dbContext.RecommendationVersionIssues
                .Where(x => x.RecommendationVersionId == recommendationVersionId)
                .ToListAsync();
        }

        public async Task<RecommendationVersionIssue> InsertAsync(RecommendationVersionIssue entity)
        {
            _dbContext.RecommendationVersionIssues.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(RecommendationVersionIssue entity)
        {
            _dbContext.RecommendationVersionIssues.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
