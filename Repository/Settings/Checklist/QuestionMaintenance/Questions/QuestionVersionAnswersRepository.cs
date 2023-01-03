using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionAnswersRepository : BaseRepository, IQuestionVersionAnswersRepository
    {
        public QuestionVersionAnswersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<QuestionVersionAnswers?>> GetByQuestionVersionId(int questionVersionId)
        {
            return await _dbContext.QuestionVersionAnswers
                .Where(x => x.QuestionVersionId == questionVersionId)
                .ToListAsync();
        }

        public async Task<QuestionVersionAnswers> InsertAsync(QuestionVersionAnswers entity)
        {
            _dbContext.QuestionVersionAnswers.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(QuestionVersionAnswers entity)
        {
            _dbContext.QuestionVersionAnswers.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
