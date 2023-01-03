using Domain.Entities.Base;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts
{
    public class LegalEntityContactType : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private LegalEntityContactType()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<LegalEntityContact>? LegalEntityContacts { get; private set; }

        public LegalEntityContactType(LegalEntityContactTypeEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(LegalEntityContactTypeEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}