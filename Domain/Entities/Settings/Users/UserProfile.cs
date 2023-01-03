using Domain.Entities.Base;
using Domain.Entities.Core;
using Domain.Enums.Settings.Users;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.Users
{
    public class UserProfile : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        private UserProfile()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor

        public virtual IEnumerable<UsersProfiles>? UsersProfiles { get; private set; }
        public virtual IEnumerable<MenuUserProfile>? MenuUserProfiles { get; private set; }

        public UserProfile(UserProfileEnum groupEnum)
        {
            Id = (int) groupEnum;
            Description = EnumDescription.CreateValid(typeof(UserProfileEnum), groupEnum, GetType().Name.ToLower());
        }
    }
}