using Adapters.Repositories.Core.Menus;
using Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Core.Menus
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _dbContext.Menus
                .ToListAsync();
        }

        public async Task<IEnumerable<Menu>> ListByUser(int userId)
        {
            return await _dbContext.MenuPersonCompacts
                .Where(x => x.UserId == userId)
                .Select(x => x.Menu)
                .ToListAsync();
        }
        
        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _dbContext.Menus
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}