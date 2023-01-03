using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntityRepository : BaseRepository, ILegalEntityRepository
    {
        public LegalEntityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LegalEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.LegalEntities
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<LegalEntity> SearchToDashboard(
            string? filter = null,
            int current = 0,
            int limit = 25,
            string? orderDirection = "asc",
            string? orderBy = null
        )
       {
            IQueryable<LegalEntity> query = _dbContext.LegalEntities.AsQueryable();

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

        public IQueryable<LegalEntity> GetAllLegalEntities()
        {
            IQueryable<LegalEntity> query = _dbContext.LegalEntities.Include(i => i.Parent).AsQueryable();

            return query;
        }

        public async Task<LegalEntity> InsertAsync(LegalEntity entity)
        {
            this._dbContext.LegalEntities.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<LegalEntity> UpdateAsync(LegalEntity entity)
        {
            this._dbContext.LegalEntities.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }
    }

}