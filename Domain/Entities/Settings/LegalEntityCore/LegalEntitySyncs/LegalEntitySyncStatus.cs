using Domain.Entities.Base;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs
{
    public class LegalEntitySyncStatus : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private LegalEntitySyncStatus()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<LegalEntitySync>? LegalEntitySyncs { get; private set; }

        public LegalEntitySyncStatus(LegalEntitySyncStatusEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(LegalEntitySyncStatusEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}