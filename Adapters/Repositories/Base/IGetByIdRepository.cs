using Domain.Entities.Base;

namespace Adapters.Repositories.Base
{
    public interface IGetByIdRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity?> GetByIdAsync(int id);
    }
}
