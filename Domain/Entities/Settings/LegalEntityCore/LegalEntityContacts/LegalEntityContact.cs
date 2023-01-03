using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;

namespace Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts
{
    public class LegalEntityContact : Entity
    {
        public int LegalEntityId { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public int LegalEntityContactTypeId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private LegalEntityContact()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual LegalEntity? LegalEntity { get; private set; }
        public virtual LegalEntityContactType? LegalEntityContactType { get; private set; }
        public virtual IEnumerable<InspectionResponsable>? InspectionResponsables { get; private set; }

        public LegalEntityContact(int legalEntityId, string name, string email, LegalEntityContactTypeEnum typeEnum)
        {
            LegalEntityId = legalEntityId;
            Name = Name.CreateValid(name, this.GetType().Name);
            Email = Email.CreateValid(email, this.GetType().Name);
            LegalEntityContactTypeId = (int)typeEnum;
        }

        public void Update(string name, string email, LegalEntityContactTypeEnum typeEnum)
        {
            Name = Name.CreateValid(name, this.GetType().Name);
            Email = Email.CreateValid(email, this.GetType().Name);
            LegalEntityContactTypeId = (int)typeEnum;
        }

    }
}