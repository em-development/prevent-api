using Domain.Entities.Base;
using Domain.Enums.Settings.Entities;
using Domain.Enums.Settings.Properties;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.PropertyCore.PropertySyncs
{
    public class PropertySyncStatus : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private PropertySyncStatus()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<PropertySync>? PropertySyncs { get; private set; }

        public PropertySyncStatus(PropertySyncStatusEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(LegalEntitySyncStatusEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}