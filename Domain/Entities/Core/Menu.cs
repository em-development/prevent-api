using Domain.Entities.Base;

namespace Domain.Entities.Core;

public class Menu : Entity
{
    public string? Title { get; private set; }
    public string? Subtitle { get; private set; }
    public string? Type { get; private set; }
    public string? Icon { get; private set; }
    public string? Link { get; private set; }
    public int? ParentId { get; private set; }

    #region EF Constructor

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618

    #endregion EF Constructor

    public virtual Menu? Parent { get; private set; }
    public IEnumerable<Menu>? Children { get; private set; }

    public virtual IEnumerable<MenuUserProfile>? MenuUserProfiles { get; private set; }
}