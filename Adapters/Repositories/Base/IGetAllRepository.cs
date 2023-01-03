using Domain.Entities.Base;

namespace Adapters.Repositories.Base
{
    public interface IGetAllRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
