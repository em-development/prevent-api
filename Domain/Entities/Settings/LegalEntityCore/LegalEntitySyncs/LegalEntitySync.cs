using Domain.Entities.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;

namespace Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs
{
    public class LegalEntitySync : Entity
    {
        public Name Name { get; private set; }
        public bool Status { get; private set; }
        public CodeEntity CodeEntity { get; private set; }
        public int? ParentId { get; private set; }
        public int LegalEntityTypeId { get; private set; }
        public int LegalEntitySyncStatusId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private LegalEntitySync()
        {
        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual LegalEntitySync? Parent { get; private set; }
        public virtual IEnumerable<LegalEntitySync>? Childrens { get; private set; }
        public virtual LegalEntityType? LegalEntityType { get; private set; }

        public LegalEntitySync(
            int id,
            string name,
            string codeEntity,
            bool status,
            int? parentId,
            LegalEntityTypeEnum typeEnum,
            LegalEntitySyncStatusEnum syncStatusEnum)
        {
            Id = id;
            Name = Name.CreateValid(name, GetType().Name);
            Status = status;
            CodeEntity = CodeEntity.CreateValid(codeEntity, GetType().Name);
            ParentId = parentId;
            LegalEntityTypeId = (int)typeEnum;
            LegalEntitySyncStatusId = (int)syncStatusEnum;
        }

        public void SetStatus(LegalEntitySyncStatusEnum status)
        {
            LegalEntitySyncStatusId = (int)status;
        }

    }
}