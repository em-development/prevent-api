using Adapters.Repositories.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.LegalEntityCore.LegalEntitySyncs
{
    public class LegalEntitySyncRepository : BaseRepository, ILegalEntitySyncRepository
    {
        public LegalEntitySyncRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LegalEntitySync?> GetByIdAsync(int id)
        {
            return await _dbContext.LegalEntitySyncs
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<LegalEntitySync> SearchToDashboard(
            string? filter = null,
            int current = 0,
            int limit = 25,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<LegalEntitySync> query = _dbContext.LegalEntitySyncs.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(i => i.Name.Value.Contains(filter) || i.CodeEntity.Value.Contains(filter));
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

            return query.Include(x => x.Childrens);
        }

        public IQueryable<LegalEntitySync> GetAllLegalEntities()
        {
            IQueryable<LegalEntitySync> query = _dbContext.LegalEntitySyncs.Include(i => i.Parent);

            return query;
        }

        public IQueryable<LegalEntitySync> GetAllLegalEntities(string? filter)
        {
            return GetAllLegalEntities()
                .Where(x => string.IsNullOrEmpty(filter) ||
                            (x.CodeEntity.Value == filter ||
                             x.Id.ToString() == filter ||
                             x.Name.Value.Contains(filter)));
        }

        public async Task<LegalEntitySync> InsertAsync(LegalEntitySync entity)
        {
            this._dbContext.LegalEntitySyncs.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<LegalEntitySync> UpdateAsync(LegalEntitySync entity)
        {
            this._dbContext.LegalEntitySyncs.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }
    }
}