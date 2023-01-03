using Domain.Entities.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntityType : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private LegalEntityType()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<LegalEntity>? LegalEntities { get; private set; }
        public virtual IEnumerable<LegalEntitySync>? LegalEntitySyncs { get; private set; }

        public LegalEntityType(LegalEntityTypeEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(LegalEntityTypeEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}