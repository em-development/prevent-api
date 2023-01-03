using Domain.Entities.Base;
using Domain.Entities.Settings.Users;
using Domain.Enums.Settings.Users;

namespace Domain.Entities.Core;

public class MenuUserProfile : Entity
{
    public int MenuId { get; private set; }
    public int ProfileId { get; private set; }

    #region EF Constructor

#pragma warning disable CS8618
    private MenuUserProfile()
    {
    }
#pragma warning restore CS8618

    #endregion EF Constructor

    public virtual Menu? Menu { get; private set; }
    public virtual UserProfile? Profile { get; private set; }

    public MenuUserProfile(int menuId, UserProfileEnum profileId)
    {
        MenuId = menuId;
        ProfileId = (int) profileId;
    }
}