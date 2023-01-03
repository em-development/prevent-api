using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionRecommendationsRepository : BaseRepository, IQuestionVersionRecommendationsRepository
    {
        public QuestionVersionRecommendationsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<QuestionVersionRecommendations?>> GetByQuestionVersionId(int questionVersionId)
        {
            return await _dbContext.QuestionVersionRecommendations
                .Where(x => x.QuestionVersionId == questionVersionId)
                .ToListAsync();
        }

        public async Task<QuestionVersionRecommendations> InsertAsync(QuestionVersionRecommendations entity)
        {
            _dbContext.QuestionVersionRecommendations.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(QuestionVersionRecommendations entity)
        {
            _dbContext.QuestionVersionRecommendations.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
