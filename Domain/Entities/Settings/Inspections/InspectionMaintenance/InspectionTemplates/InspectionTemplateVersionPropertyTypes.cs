using Domain.Entities.Base;
using Domain.Entities.Settings.PropertyCore.Properties;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionPropertyTypes : Entity
    {
        public int InspectionTemplateVersionId { get; private set; }
        public int PropertyTypeId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private InspectionTemplateVersionPropertyTypes()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual InspectionTemplateVersion? InspectionTemplateVersion { get; private set; }
        public virtual PropertyType? PropertyType { get; private set; }

        public InspectionTemplateVersionPropertyTypes(int inspectionTemplateVersionId, int propertyTypeId)
        {
            InspectionTemplateVersionId = inspectionTemplateVersionId;
            PropertyTypeId = propertyTypeId;
        }
    }
}
