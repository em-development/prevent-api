using Domain.Entities.Base;
using Domain.Entities.Core;

namespace Domain.Compacts.Settings.Core.Menus
{
    public class MenuUserCompact : Entity
    {
        public Menu Menu { get; set; }
        public int UserId { get; set; }

        #region EF Constructor

#pragma warning disable CS8618
        private MenuUserCompact()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor
    }
}