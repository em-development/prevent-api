using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;
using DomainChecklistMaintenance = Domain.Entities.Settings.Checklist.ChecklistMaintenance;

namespace Repository.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistRepository : BaseRepository, IChecklistRepository
    {
        public ChecklistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<DomainChecklistMaintenance.Checklist?> GetByIdAsync(int id)
        {
            return await _dbContext.Checklists
                .Include(i => i.Version)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<DomainChecklistMaintenance.Checklist> SearchToDashboard(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            var query = _dbContext.Checklists
                .Include(x => x.Version)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query
                    .Where(i => i.Version != null && i.Version.Title.Value.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderDirection) && orderDirection == "asc")
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "title")
                {
                    query = query.OrderBy(i => i.Version != null ? i.Version.Title.Value : null);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "title")
                {
                    query = query.OrderByDescending(i => i.Version != null ? i.Version.Title.Value : null);
                }
            }

            return query;
        }

        public IQueryable<DomainChecklistMaintenance.Checklist> SearchToSideForm(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            return SearchToDashboard(filter, orderDirection, orderBy)
                .Include(i => i.Version)
                .ThenInclude(i => i!.ChecklistVersionQuestions)!
                .ThenInclude(i => i.Question)
                .ThenInclude(i => i!.Version);
        }

        public async Task<DomainChecklistMaintenance.Checklist?> GetByIdWithVersions(int id)
        {
            return await _dbContext.Checklists
                .Include(i => i.ChecklistVersions)
                .Include(i => i.Version)
                .ThenInclude(i => i!.ChecklistVersionQuestions)!
                .ThenInclude(i => i.Question)
                .ThenInclude(i => i!.Version)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<DomainChecklistMaintenance.Checklist>?> GetByInspectionTemplateVersionId(int id)
        {
            return (await _dbContext.InspectionTemplateVersionChecklists
                .Where(x => x.InspectionTemplateVersion!.Id == id)
                .Include(i => i.Checklist)
                .ThenInclude(i => i!.Version)
                .ThenInclude(i => i!.ChecklistVersionQuestions)!
                .ThenInclude(i => i.Question)
                .ThenInclude(i => i!.Version)
                .ThenInclude(i => i!.QuestionVersionAnswers)!
                .ThenInclude(i => i.AnswerVersion)
                .Select(x => x.Checklist)
                .ToListAsync())!;
        }

        public async Task<IEnumerable<DomainChecklistMaintenance.Checklist>?> GetByInspectionTemplateVersionIdToAnswer(
            int id,
            int inspectionId)
        {
            return (await _dbContext.InspectionTemplateVersionChecklists
                .Where(x => x.InspectionTemplateVersion!.Id == id)
                .Include(i => i.Checklist)
                .Include(i => i.Checklist)
                .ThenInclude(i => i!.Version)
                .ThenInclude(i => i!.ChecklistVersionQuestions)!
                .ThenInclude(i => i.Question)
                .ThenInclude(i => i!.Version)
                .ThenInclude(i => i!.QuestionVersionAnswers)!
                .ThenInclude(i => i.AnswerVersion)
                .ThenInclude(i => i!.AnswerVersionIssues)!
                .ThenInclude(i => i.Issue)
                // .ThenInclude(i => i!.RecommendationVersionIssues!
                //     .Where(evi => evi.RecommendationVersion!.Recommendation!.IsActive))
                // .ThenInclude(i => i.RecommendationVersion)
                .Select(x => x.Checklist)
                .ToListAsync())!;
        }

        public async Task<DomainChecklistMaintenance.Checklist> InsertAsync(DomainChecklistMaintenance.Checklist entity)
        {
            _dbContext.Checklists.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<DomainChecklistMaintenance.Checklist> UpdateAsync(DomainChecklistMaintenance.Checklist entity)
        {
            _dbContext.Checklists.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}