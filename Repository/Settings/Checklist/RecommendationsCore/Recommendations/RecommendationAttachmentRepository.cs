using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationAttachmentRepository : BaseRepository, IRecommendationAttachmentRepository
    {
        public RecommendationAttachmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<RecommendationAttachment?> GetByIdAsync(int id)
        {
            return await _dbContext.RecommendationAttachments
                .Include(i => i.Attachment)
                .Include(i => i.RecommendationVersion)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<RecommendationAttachment?>> GetByRecommendationVersionId(int recommendationVersionId)
        {
            return await _dbContext.RecommendationAttachments
                .Where(x => x.RecommendationVersionId == recommendationVersionId)
                .ToListAsync();
        }

        public async Task<RecommendationAttachment> InsertAsync(RecommendationAttachment entity)
        {
            _dbContext.RecommendationAttachments.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<RecommendationAttachment> UpdateAsync(RecommendationAttachment entity)
        {
            _dbContext.RecommendationAttachments.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

    }
}
