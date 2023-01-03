using Domain.Entities.Base;

namespace Adapters.Repositories.Base
{
    public interface IRemoveRepository<TEntity> where TEntity : Entity
    {
        Task RemoveAsync(TEntity entity);
    }
}
