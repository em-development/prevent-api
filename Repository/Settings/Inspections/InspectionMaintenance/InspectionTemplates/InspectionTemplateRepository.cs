using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateRepository : BaseRepository, IInspectionTemplateRepository
    {
        public InspectionTemplateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<InspectionTemplate?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionTemplates
                .Include(i => i.Version)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<InspectionTemplate> SearchToDashboard(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<InspectionTemplate> query = _dbContext.InspectionTemplates
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

        public IQueryable<InspectionTemplate> SearchToSideForm(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            return SearchToDashboard(filter, orderDirection, orderBy)
                .Include(i => i.Version)
                .ThenInclude(i => i.InspectionTemplateVersionChecklists)
                .ThenInclude(i => i.Checklist)
                .ThenInclude(i => i.Version);
        }

        public IQueryable<InspectionTemplate> SearchByPropertyTypeId(
            int propertyTypeId,
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<InspectionTemplate> query = _dbContext.InspectionTemplates
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query
                    .Where(i => i.Version != null && i.Version.Title.Value.Contains(filter));
            }

            query = query.Where(x => x.Version.InspectionTemplateVersionPropertyTypes
                                      .Select(x => x.PropertyTypeId)
                                      .Contains(propertyTypeId));

            return query
                .Include(i => i.Version)
                .ThenInclude(i => i.InspectionTemplateVersionChecklists)
                .ThenInclude(i => i.Checklist)
                .ThenInclude(i => i.Version);
        }

        public async Task<InspectionTemplate?> GetByIdWithVersions(int id)
        {
#pragma warning disable CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
            return await _dbContext.InspectionTemplates
                .Include(i => i.InspectionTemplateVersions)
#pragma warning restore CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
                .Include(i => i.Version)
                .ThenInclude(i => i.InspectionTemplateVersionChecklists)
                .ThenInclude(i => i.Checklist)
                .ThenInclude(i => i.Version)
                .Include(i => i.Version)
                .ThenInclude(i => i.InspectionTemplateVersionPropertyTypes)
                .ThenInclude(i => i.PropertyType)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<InspectionTemplate> InsertAsync(InspectionTemplate entity)
        {
            _dbContext.InspectionTemplates.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionTemplate> UpdateAsync(InspectionTemplate entity)
        {
            _dbContext.InspectionTemplates.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
