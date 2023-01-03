using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.Settings.Properties;

namespace Domain.Entities.Settings.PropertyCore.Properties
{
    public class Property : Entity
    {
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public Code? Code { get; private set; }
        public int LegalEntityId { get; private set; }
        public int PropertyTypeId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private Property()
        {
        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual LegalEntity? LegalEntity { get; private set; }
        public virtual PropertyType? PropertyType { get; private set; }
        public virtual IEnumerable<Inspection>? Inspections { get; private set; }

        public Property(int id, string name, string address, string code, int legalEntityId, PropertyTypeEnum typeEnum)
        {
            Id = id;
            Name = Name.CreateValid(name, GetType().Name);
            Address = Address.CreateValid(address, GetType().Name);
            Code = Code.CreateValid(code, GetType().Name);
            LegalEntityId = legalEntityId;
            PropertyTypeId = (int)typeEnum;
        }

    }
}