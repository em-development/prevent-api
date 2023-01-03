using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerRepository : BaseRepository, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Answer?> GetByIdAsync(int id)
        {
            return await _dbContext.Answers
                .Include(i => i.Version)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Answer> SearchToDashboard(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<Answer> query = _dbContext.Answers
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

        public IQueryable<Answer> SearchToSideForm(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            return SearchToDashboard(filter, orderDirection, orderBy)
                .Include(i => i.AnswerVersions)
                .Include(i => i.Version)
                .ThenInclude(i => i.AnswerVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags);
        }

        public async Task<Answer?> GetByIdWithVersions(int id)
        {
#pragma warning disable CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
            return await _dbContext.Answers
                .Include(i => i.AnswerVersions)
#pragma warning restore CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
                .Include(i => i.Version)
                .ThenInclude(i => i.AnswerVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Answer> InsertAsync(Answer entity)
        {
            this._dbContext.Answers.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Answer> UpdateAsync(Answer entity)
        {
            this._dbContext.Answers.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
