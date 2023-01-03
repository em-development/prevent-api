using Domain.Entities.Base;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplate : Entity
    {
        public int? VersionId { get; private set; }
        public bool IsActive { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public InspectionTemplate()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual InspectionTemplateVersion? Version { get; private set; }
        public virtual IEnumerable<InspectionTemplateVersion>? InspectionTemplateVersions { get; private set; }

        public InspectionTemplate(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetVersion(int versionId)
        {
            VersionId = versionId;
        }

        public void SetVersion(InspectionTemplateVersion inspectionTemplateVersion)
        {
            Version = inspectionTemplateVersion;
        }
    }
}
