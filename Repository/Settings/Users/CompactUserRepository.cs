using Adapters.Repositories.Settings.Users;
using Domain.Compacts.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Users
{
    public sealed class CompactUserRepository : BaseRepository, ICompactUserRepository
    {
        public CompactUserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<CompactUser?> GetBySubjectIdAsync(string subjectId)
            => await _dbContext.CompactUsers
                    .Include(u => u.Avatar)
                    .SingleOrDefaultAsync(u => (u.UId == null ? null : u.UId) == subjectId);

        public async Task<CompactUser?> GetByEmailAsync(string email)
            => await _dbContext.CompactUsers
                    .Include(u => u.Avatar)
                    .SingleOrDefaultAsync(u => (u.Email == null ? null : u.Email) == email);
    }
}
