using Domain.Entities.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.Entities.Settings.Users;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;

namespace Domain.Entities.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntity : Entity
    {
        public Name Name { get; private set; }
        public bool Status { get; private set; }
        public CodeEntity CodeEntity { get; private set; }
        public int? ParentId { get; private set; }
        public int LegalEntityTypeId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private LegalEntity()
        {
        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual LegalEntity? Parent { get; private set; }
        public virtual IEnumerable<LegalEntity>? Childrens { get; private set; }
        public virtual IEnumerable<LegalEntityContact> LegalEntityContacts { get; private set; }
        public virtual IEnumerable<Property> Properties { get; private set; }
        public virtual IEnumerable<PropertySync> PropertySyncs { get; private set; }
        public virtual IEnumerable<UsersLegalEntities> UsersLegalEntities { get; private set; }
        public virtual LegalEntityType? LegalEntityType { get; private set; }

        public LegalEntity(int id, string name, string codeEntity, bool status, int? parentId, LegalEntityTypeEnum typeEnum)
        {
            Id = id;
            Name = Name.CreateValid(name, GetType().Name);
            Status = status;
            CodeEntity = CodeEntity.CreateValid(codeEntity, GetType().Name);
            ParentId = parentId;
            LegalEntityTypeId = (int)typeEnum;
        }

    }
}