using Domain.Entities.Base;
using Domain.Enums.Settings.Users;

namespace Domain.Entities.Settings.Users
{
    public class UsersProfiles : Entity
    {
        public int UserId { get; private set; }
        public int UserProfileId { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        private UsersProfiles()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor

        public virtual User? User { get; private set; }
        public virtual UserProfile? UserProfile { get; private set; }

        public UsersProfiles(int userId, UserProfileEnum typeEnum)
        {
            UserId = userId;
            UserProfileId = (int) typeEnum;
        }
    }
}