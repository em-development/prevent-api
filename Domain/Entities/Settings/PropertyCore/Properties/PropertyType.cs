using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.Enums.Settings.Entities;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.PropertyCore.Properties
{
    public class PropertyType : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private PropertyType()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<Property>? Properties { get; private set; }
        public virtual IEnumerable<InspectionTemplateVersionPropertyTypes>? InspectionTemplateVersionPropertyTypes { get; private set; }
        public virtual IEnumerable<PropertySync>? PropertySyncs { get; private set; }

        public PropertyType(PropertyTypeEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(PropertyTypeEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}