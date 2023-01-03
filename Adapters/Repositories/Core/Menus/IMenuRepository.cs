using Adapters.Repositories.Base;
using Domain.Entities.Core;

namespace Adapters.Repositories.Core.Menus
{
    public interface IMenuRepository :
        IGetByIdRepository<Menu>,
        IGetAllRepository<Menu>
    {
        Task<IEnumerable<Menu>> ListByUser(int userId);
    }
}