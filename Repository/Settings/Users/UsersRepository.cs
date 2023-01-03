using Adapters.Repositories.Base;
using Adapters.Repositories.Settings.Users;
using Domain.Entities.Settings.Users;
using Domain.Enums.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Users
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<User> SearchToDashboard(
            string? filter = null,
            int current = 0,
            int limit = 25,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            IQueryable<User> query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(i =>
                    i.Name.Value.Contains(filter) || i.UId.Value.Contains(filter) || i.Email.Value.Contains(filter));
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

            return query;
        }

        public async Task<User?> GetByUId(string uId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UId != null
                                                                   && x.UId.Value == uId);
        }

        async Task<User?> IGetByIdRepository<User>.GetByIdAsync(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<User>> GetInspectorsByLegalEntityId(int legaEntityId)
        {
            return await _dbContext.UsersProfiles
                .Include(i => i.User)
                .ThenInclude(i => i.UsersLegalEntities)
                .Where(x => (UserProfileEnum)x.UserProfileId == UserProfileEnum.INSPECTOR && 
                            x.User.UsersLegalEntities.Select(s => s.LegalEntityId).Contains(legaEntityId))
                .Select(x => x.User)
                .ToListAsync();
        }

        public async Task<User> InsertAsync(User entity)
        {
            _dbContext.Users.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(User entity)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return;
        }
    }
}