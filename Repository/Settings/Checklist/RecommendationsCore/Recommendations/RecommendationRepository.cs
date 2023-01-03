using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationRepository : BaseRepository, IRecommendationRepository
    {
        public RecommendationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Recommendation?> GetByIdAsync(int id)
        {
            return await _dbContext.Recommendations
                .Include(i => i.Version)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Recommendation> SearchToDashboard(
            int status,
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<Recommendation> query = _dbContext.Recommendations
                .Include(x => x.Version)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query
                    .Where(i => i.Version != null && (i.Version.Title.Value.Contains(filter) || i.Version.Description.Value.Contains(filter)));
            }

            if (status != 0)
            {
                query = query
                    .Where(i => i.Version != null ? i.Version.RecommendationVersionStatusId == status : true);
            }

            if (!string.IsNullOrEmpty(orderDirection) && orderDirection == "asc")
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "description")
                {
                    query = query.OrderBy(i => i.Version != null ? i.Version.Description.Value : null);
                }
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "title")
                {
                    query = query.OrderBy(i => i.Version != null ? i.Version.Title.Value : null);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "description")
                {
                    query = query.OrderByDescending(i => i.Version != null ? i.Version.Description.Value : null);
                }
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "title")
                {
                    query = query.OrderByDescending(i => i.Version != null ? i.Version.Title.Value : null);
                }
            }

            return query;
        }

        public IQueryable<Recommendation> SearchToSideForm(
            int status,
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            return SearchToDashboard(status, filter, orderDirection, orderBy)
                .Include(i => i.RecommendationVersions)
                .Include(i => i.Version)
                .ThenInclude(i => i.RecommendationVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Include(i => i.Version)
                .ThenInclude(i => i.RecommendationAttachments)
                .ThenInclude(i => i.Attachment);
        }

        public async Task<Recommendation?> GetByIdWithVersions(int id)
        {
#pragma warning disable CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
            return await _dbContext.Recommendations
                .Include(i => i.RecommendationVersions)
#pragma warning restore CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
                .Include(i => i.Version)
                .ThenInclude(i => i.RecommendationVersionIssues)
                .ThenInclude(i => i.Issue)
                .ThenInclude(i => i.Tags)
                .Include(i => i.Version)
                .ThenInclude(i => i.RecommendationAttachments)
                .ThenInclude(i => i.Attachment)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Recommendation> InsertAsync(Recommendation entity)
        {
            _dbContext.Recommendations.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Recommendation> UpdateAsync(Recommendation entity)
        {
            _dbContext.Recommendations.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

    }
}
