using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.ValueObjects.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersion : Entity
    {
        public int InspectionTemplateId { get; private set; }
        public Title Title { get; private set; }
        public int Version { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private InspectionTemplateVersion()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual InspectionTemplate? InspectionTemplate { get; private set; }
        public virtual IEnumerable<InspectionTemplateVersionChecklists>? InspectionTemplateVersionChecklists { get; private set; }
        public virtual IEnumerable<InspectionTemplateVersionPropertyTypes>? InspectionTemplateVersionPropertyTypes { get; private set; }
        public virtual IEnumerable<Inspection>? Inspections { get; private set; }

        public InspectionTemplateVersion(
            int inspectionTemplateId,
            string title,
            int version
        )
        {
            InspectionTemplateId = inspectionTemplateId;
            Title = Title.CreateValid(title, GetType().Name);
            Version = version;
        }

        public void IncrementVersion(int currentVersion)
        {
            Version = currentVersion + 1;
        }

        public void SetTitle(string title)
        {
            Title = Title.CreateValid(title, GetType().Name);
        }
    }
}
