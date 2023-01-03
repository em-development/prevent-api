using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionRepository : BaseRepository, IQuestionVersionRepository
    {
        public QuestionVersionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<QuestionVersion>?> GetByQuestionId(int questionId)
        {
            return await _dbContext.QuestionVersions
                .Include(i => i.QuestionVersionAnswers)
                .ThenInclude(i => i.AnswerVersion)
                .ThenInclude(i => i.AnswerVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Include(i => i.QuestionVersionRecommendations)
                .ThenInclude(i => i.RecommendationVersion)
                .ThenInclude(i => i.RecommendationVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Include(i => i.SubQuestionVersions)
                .ThenInclude(i => i.SubQuestionVersion)
                .Where(x => x.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<QuestionVersion> InsertAsync(QuestionVersion entity)
        {
            _dbContext.QuestionVersions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(QuestionVersion entity)
        {
            _dbContext.QuestionVersions.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
