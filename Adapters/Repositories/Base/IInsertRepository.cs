using Domain.Entities.Base;

namespace Adapters.Repositories.Base
{
    public interface IInsertRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> InsertAsync(TEntity entity);
    }
}
