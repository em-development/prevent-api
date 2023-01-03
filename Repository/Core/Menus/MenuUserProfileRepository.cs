using Adapters.Repositories.Core.Menus;
using Domain.Entities.Core;
using Domain.Enums.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Core.Menus
{
    public class MenuUserProfileRepository : BaseRepository, IMenuUserProfileRepository
    {
        public MenuUserProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<MenuUserProfile>> ListByUserProfileAsync(UserProfileEnum profileEnum)
        {
            return await _dbContext.MenuUserProfiles
                .Where(x => x.ProfileId == (int) profileEnum)
                .ToListAsync();
        }

        public async Task<MenuUserProfile?> GetByProfileEnumAndMenuIdAsync(int menuId, UserProfileEnum profileEnum)
        {
            return await _dbContext.MenuUserProfiles
                .FirstOrDefaultAsync(x => x.ProfileId == (int) profileEnum
                                          && x.MenuId == menuId);
        }

        public async Task<MenuUserProfile> InsertAsync(MenuUserProfile entity)
        {
            _dbContext.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(MenuUserProfile entity)
        {
            _dbContext.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}