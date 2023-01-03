using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Domain.Entities.Settings.Checklist.ChecklistMaintenance
{
    public class Checklist : Entity
    {
        public int? VersionId { get; private set; }
        public bool IsActive { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public Checklist()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual ChecklistVersion? Version { get; private set; }
        public virtual IEnumerable<ChecklistVersion>? ChecklistVersions { get; private set; }
        public virtual IEnumerable<InspectionTemplateVersionChecklists>? InspectionTemplateVersionChecklists { get; private set; }

        public Checklist(bool isActive)
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

        public void SetVersion(ChecklistVersion checklistVersion)
        {
            Version = checklistVersion;
        }
    }
}
