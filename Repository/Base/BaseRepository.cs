using Repository.Configuration.Context;

namespace Repository.Base
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        protected BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
