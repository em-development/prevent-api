using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _dbContext.Questions
                .Include(i => i.Version)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Question> SearchToDashboard(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<Question> query = _dbContext.Questions
                .Include(x => x.Version)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query
                    .Where(i => i.Version != null && i.Version.Description.Value.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderDirection) && orderDirection == "asc")
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "description")
                {
                    query = query.OrderBy(i => i.Version != null ? i.Version.Description.Value : null);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "description")
                {
                    query = query.OrderByDescending(i => i.Version != null ? i.Version.Description.Value : null);
                }
            }

            return query;
        }

        public IQueryable<Question> SearchToSideForm(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            return SearchToDashboard(filter, orderDirection, orderBy)
                .Include(i => i.QuestionVersions)
                .Include(i => i.Version)
                .ThenInclude(i => i.QuestionVersionAnswers)
                .ThenInclude(i => i.AnswerVersion)
                .Include(i => i.QuestionVersions)
                .ThenInclude(i => i.QuestionVersionRecommendations)
                .ThenInclude(i => i.RecommendationVersion)
                .Include(i => i.Version)
                .ThenInclude(i => i.SubQuestionVersions);
        }

        public async Task<Question?> GetByIdWithVersions(int id)
        {
#pragma warning disable CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
            return await _dbContext.Questions
                .Include(i => i.QuestionVersions)
#pragma warning restore CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
                .Include(i => i.Version)
                .ThenInclude(i => i.QuestionVersionAnswers)
                .ThenInclude(i => i.AnswerVersion)
                .ThenInclude(i => i.AnswerVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Include(i => i.Version)
                .ThenInclude(i => i.QuestionVersionRecommendations)
                .ThenInclude(i => i.RecommendationVersion) 
                .ThenInclude(i => i.RecommendationVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Include(i => i.Version)
                .ThenInclude(i => i.SubQuestionVersions)
                .ThenInclude(i => i.SubQuestionVersion)
                .ThenInclude(i => i.QuestionVersionAnswers)
                .ThenInclude(i => i.AnswerVersion)
                .ThenInclude(i => i.AnswerVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Question>?> GetByChecklistVersionId(int id)
        {
            return await _dbContext.ChecklistVersionQuestions
                .Where(x => x.ChecklistVersion.Id == id)
                .Include(i => i.Question)
                .ThenInclude(i => i.Version)
                .ThenInclude(i => i.QuestionType)
                .Include(i => i.Question)
                .ThenInclude(i => i.Version)
                .ThenInclude(i => i.QuestionVersionAnswers)
                .ThenInclude(i => i.AnswerVersion)
                .Select(x => x.Question)
                .ToArrayAsync();
        }

        public async Task<Question> InsertAsync(Question entity)
        {
            _dbContext.Questions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Question> UpdateAsync(Question entity)
        {
            _dbContext.Questions.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
