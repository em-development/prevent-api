using Adapters.Repositories.Settings.Users;
using Domain.Entities.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Users
{
    public class UsersLegalEntitiesRepository : BaseRepository, IUsersLegalEntitiesRepository
    {
        public UsersLegalEntitiesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<int>> GetLegalEntitiesByUserId(int userId)
        {
            return await _dbContext.UsersLegalEntities
                .Where(x => x.UserId == userId)
                .Select(x => x.LegalEntityId)
                .ToListAsync();
        }

        public async Task<UsersLegalEntities?> GetByUserIdAndLegalEntityId(int userId, int legalEntityId)
        {
            return await _dbContext.UsersLegalEntities
                .Where(x => x.UserId == userId && x.LegalEntityId == legalEntityId)
                .FirstOrDefaultAsync();
        }

        public async Task<UsersLegalEntities> InsertAsync(UsersLegalEntities entity)
        {
            _dbContext.UsersLegalEntities.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UsersLegalEntities> UpdateAsync(UsersLegalEntities entity)
        {
            _dbContext.UsersLegalEntities.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(UsersLegalEntities entity)
        {
            _dbContext.UsersLegalEntities.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return;
        }

        public async Task RemoveAllByUserId(int userId)
        {
            var userLegalEntitiesToRemove = _dbContext.UsersLegalEntities
                .Where(x => x.UserId == userId)
                .ToList();

            foreach (var item in userLegalEntitiesToRemove)
            {
                _dbContext.UsersLegalEntities.Remove(item);
                await _dbContext.SaveChangesAsync();
            }

            return;
        }
    }
}