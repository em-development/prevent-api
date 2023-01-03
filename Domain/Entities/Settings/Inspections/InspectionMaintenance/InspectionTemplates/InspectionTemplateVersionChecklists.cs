using Domain.Entities.Base;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionChecklists : Entity
    {
        public int InspectionTemplateVersionId { get; private set; }
        public int ChecklistId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private InspectionTemplateVersionChecklists()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual InspectionTemplateVersion? InspectionTemplateVersion { get; private set; }
        public virtual Checklist.ChecklistMaintenance.Checklist? Checklist { get; private set; }

        public InspectionTemplateVersionChecklists(int inspectionTemplateVersionId, int checklistId)
        {
            InspectionTemplateVersionId = inspectionTemplateVersionId;
            ChecklistId = checklistId;
        }
    }
}
