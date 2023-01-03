using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionRepository : BaseRepository, IRecommendationVersionRepository
    {
        public RecommendationVersionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<RecommendationVersion?> GetByIdAsync(int id)
        {
            return await _dbContext.RecommendationVersions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RecommendationVersion>?> GetByRecommendationId(int recommendationId)
        {
            return await _dbContext.RecommendationVersions
                .Where(x => x.RecommendationId == recommendationId)
                .ToListAsync();
        }

        public async Task<RecommendationVersion> InsertAsync(RecommendationVersion entity)
        {
            _dbContext.RecommendationVersions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(RecommendationVersion entity)
        {
            _dbContext.RecommendationVersions.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<RecommendationVersion?> Approve(RecommendationVersion entity)
        {
            entity?.SetStatusApprove();

            _dbContext.RecommendationVersions.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<RecommendationVersion?> Disapprove(RecommendationVersion entity)
        {
            entity?.SetStatusDisapprove();

            _dbContext.RecommendationVersions.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}