using Domain.Entities.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;

namespace Domain.Entities.Settings.Users
{
    public class UsersLegalEntities : Entity
    {
        public int UserId { get; private set; }
        public int LegalEntityId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private UsersLegalEntities()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual User? User { get; private set; }
        public virtual LegalEntity? LegalEntity { get; private set; }

        public UsersLegalEntities(int userId, int legalEntityId)
        {
            UserId = userId;
            LegalEntityId = legalEntityId;
        }

    }
}
