using Domain.Entities.Base;

namespace Adapters.Repositories.Base
{
    public interface IUpdateRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
