using Adapters.Repositories.Settings.PropertyCore.PropertySyncs;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.Enums.Settings.Properties;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.PropertyCore.PropertySyncs
{
    public class PropertySyncRepository : BaseRepository, IPropertySyncRepository
    {
        public PropertySyncRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PropertySync?> GetByIdAsync(int id)
        {
            return await _dbContext.PropertySyncs
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<PropertySync> SearchToDashboard(
            string? filter = null,
            int current = 0,
            int limit = 25,
            string? orderDirection = "asc",
            string? orderBy = null,
            bool onlyDifferent = false
        )
        {
            IQueryable<PropertySync> query = _dbContext.PropertySyncs.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(i => i.Name.Value.Contains(filter)
                                         || (i.Code != null && i.Code.Value.Contains(filter)));
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

            if (onlyDifferent)
            {
                query = query.Where(x => x.PropertySyncStatusId != (int) PropertySyncStatusEnum.SYNCED);
            }

            return query.Include(x => x.LegalEntity);
        }

        public IQueryable<PropertySync> GetAllProperties()
        {
            IQueryable<PropertySync> query = _dbContext.PropertySyncs.AsQueryable();

            return query;
        }

        public IQueryable<PropertySync> GetAllProperties(string filter)
        {
            return GetAllProperties()
                .Where(x => string.IsNullOrEmpty(filter) || (
                    (x.Code != null && x.Code.Value == filter)
                    || x.Name.Value.Contains(filter)
                ));
        }

        public async Task<PropertySync> InsertAsync(PropertySync entity)
        {
            this._dbContext.PropertySyncs.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<PropertySync> UpdateAsync(PropertySync entity)
        {
            this._dbContext.PropertySyncs.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }
    }
}