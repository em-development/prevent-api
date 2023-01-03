using Adapters.Repositories.Settings.PropertyCore.Properties;
using Domain.Entities.Settings.PropertyCore.Properties;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.PropertyCore.Properties
{
    public class PropertyRepository : BaseRepository, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Property?> GetByIdAsync(int id)
        {
            return await _dbContext.Properties
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Property> SearchToDashboard(
            string? filter = null,
            int current = 0,
            int limit = 25,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<Property> query = _dbContext.Properties.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(i => i.Name.Value.Contains(filter) || i.Code.Value.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderDirection) && orderDirection == "asc")
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "name")
                {
                    query = query.OrderBy(i => i.Name.Value);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "name")
                {
                    query = query.OrderByDescending(i => i.Name.Value);
                }
            }

            return query.Include(x => x.LegalEntity);
        }

        public IQueryable<Property> SearchByLegalEntityId(
            int legalEntityId,
            string? filter = null,
            int current = 0,
            int limit = 25,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<Property> properties = SearchToDashboard(filter, current, limit, orderDirection, orderBy);

            return properties.Where(x => x.LegalEntityId == legalEntityId);
        }

        public async Task<IEnumerable<PropertyType>> GetPropertyTypes()
        {
            return await _dbContext.PropertyTypes
                .ToListAsync();
        }

        public async Task<IEnumerable<int>?> GetByInspectionTemplateVersionId(int id)
        {
            var propertyTypes = await _dbContext.InspectionTemplateVersionPropertyTypes
                .Where(x => x.InspectionTemplateVersion.Id == id)
                .Include(i => i.PropertyType)
                .Select(x => x.PropertyType)
                .ToArrayAsync();

            return propertyTypes != null ? propertyTypes.Select(x => x.Id) : Array.Empty<int>();
        }

        public IQueryable<Property> GetAllProperties(string? filter = null)
        {
            var query = _dbContext.Properties
                .Where(p => string.IsNullOrEmpty(filter)
                            || (p.Name.Value.Contains(filter)
                                || (p.Code != null && p.Code.Value == filter)))
                .AsQueryable();

            return query;
        }

        public async Task<Property> InsertAsync(Property entity)
        {
            this._dbContext.Properties.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Property> UpdateAsync(Property entity)
        {
            this._dbContext.Properties.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }
    }
}