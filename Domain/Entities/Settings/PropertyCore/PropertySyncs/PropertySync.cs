using Domain.Entities.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.Enums.Settings.Entities;
using Domain.Enums.Settings.Properties;
using Domain.ValueObjects.Settings.Properties;

namespace Domain.Entities.Settings.PropertyCore.PropertySyncs
{
    public class PropertySync : Entity
    {
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public Code? Code { get; private set; }
        public int LegalEntityId { get; private set; }
        public int PropertyTypeId { get; private set; }
        public int PropertySyncStatusId { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        private PropertySync()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor

        public virtual LegalEntity? LegalEntity { get; private set; }
        public virtual PropertyType? PropertyType { get; private set; }

        public PropertySync(
            int id,
            string name,
            string address,
            string? code,
            int legalEntityId,
            PropertyTypeEnum typeEnum,
            PropertySyncStatusEnum syncStatusEnum
        )
        {
            Id = id;
            Address = Address.CreateValid(address, GetType().Name);
            Name = Name.CreateValid(name, GetType().Name);
            Code = code != null ? Code.CreateValid(code, GetType().Name) : null;
            LegalEntityId = legalEntityId;
            PropertyTypeId = (int) typeEnum;
            PropertySyncStatusId = (int) syncStatusEnum;
        }

        public void SetStatus(PropertySyncStatusEnum status)
        {
            PropertySyncStatusId = (int) status;
        }
    }
}