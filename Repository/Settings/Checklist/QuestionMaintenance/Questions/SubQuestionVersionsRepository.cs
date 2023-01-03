using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.QuestionMaintenance.Questions
{
    public class SubQuestionVersionsRepository : BaseRepository, ISubQuestionVersionsRepository
    {
        public SubQuestionVersionsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<SubQuestionVersions?>> GetByQuestionVersionId(int questionVersionId)
        {
            return await _dbContext.SubQuestionVersions
                .Where(x => x.QuestionVersionId == questionVersionId)
                .ToListAsync();
        }

        public async Task<SubQuestionVersions> InsertAsync(SubQuestionVersions entity)
        {
            _dbContext.SubQuestionVersions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(SubQuestionVersions entity)
        {
            _dbContext.SubQuestionVersions.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
