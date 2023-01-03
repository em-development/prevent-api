using Adapters.Repositories.Base;
using Domain.Entities.Core;
using Domain.Enums.Settings.Users;

namespace Adapters.Repositories.Core.Menus
{
    public interface IMenuUserProfileRepository :
        IInsertRepository<MenuUserProfile>,
        IRemoveRepository<MenuUserProfile>
    {
        Task<IEnumerable<MenuUserProfile>> ListByUserProfileAsync(UserProfileEnum profileEnum);

        Task<MenuUserProfile?> GetByProfileEnumAndMenuIdAsync(int menuId, UserProfileEnum profileEnum);
    }
}