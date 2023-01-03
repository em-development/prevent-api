using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Users;

namespace Domain.Entities.Settings.Users
{
    public class User : Entity
    {
        public Name Name { get; private set; }
        public Email? Email { get; private set; }
        public UId? UId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private User()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<UsersProfiles> UsersProfiles { get; private set; }
        public virtual IEnumerable<UsersLegalEntities> UsersLegalEntities { get; private set; }
        public virtual IEnumerable<Inspection> Inspections { get; private set; }

        public User(string name, string email, string uId)
        {
            Name = Name.CreateValid(name, GetType().Name.ToLower());
            Email = email == null ? null : Email.CreateValid(email, GetType().Name.ToLower());
            UId = uId != null ? UId.CreateValid(uId, GetType().Name.ToLower()) : null;
        }

        public void UpdateName(string name)
        {
            Name = Name.CreateValid(name, GetType().Name.ToLower());
        }

        public void UpdateEmail(string email)
        {
            Email = email == null ? null : Email.CreateValid(email, GetType().Name.ToLower());
        }

        public void UpdateUId(string uid)
        {
            UId = uid == null ? null : UId.CreateValid(uid, GetType().Name.ToLower());
        }
    }
}
