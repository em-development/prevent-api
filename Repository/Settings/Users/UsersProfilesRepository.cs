using Adapters.Repositories.Base;
using Adapters.Repositories.Settings.Users;
using Domain.Entities.Settings.Users;
using Domain.Enums.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Users
{
    public class UsersProfilesRepository : BaseRepository, IUsersProfilesRepository
    {
        public UsersProfilesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<int>> GetUsersProfilesByUserId(int userId)
        {
            return await _dbContext.UsersProfiles
                .Where(x => x.UserId == userId)
                .Select(x => x.UserProfileId)
                .ToListAsync();
        }

        public async Task<UsersProfiles?> GetByUserIdAndUserProfileId(int userId, int userProfileId)
        {
            return await _dbContext.UsersProfiles
                .Where(x => x.UserId == userId && x.UserProfileId == userProfileId)
                .FirstOrDefaultAsync();
        }

        public async Task<UsersProfiles> InsertAsync(UsersProfiles entity)
        {
            _dbContext.UsersProfiles.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UsersProfiles> UpdateAsync(UsersProfiles entity)
        {
            _dbContext.UsersProfiles.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(UsersProfiles entity)
        {
            _dbContext.UsersProfiles.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return;
        }

        public async Task RemoveAllByUserId(int userId)
        {
            var userProfilesToRemove = _dbContext.UsersProfiles
                .Where(x => x.UserId == userId)
                .ToList();

            foreach (var item in userProfilesToRemove)
            {
                _dbContext.UsersProfiles.Remove(item);
                await _dbContext.SaveChangesAsync();
            }

            return;
        }
    }
}