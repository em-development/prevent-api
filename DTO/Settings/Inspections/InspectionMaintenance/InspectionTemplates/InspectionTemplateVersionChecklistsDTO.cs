using DTO.Settings.Checklist.ChecklistMaintenance;

namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionChecklistsDTO
    {
        public int Id { get; set; }
        public InspectionTemplateVersionDTO? InspectionTemplateVersion { get; set; }
        public ChecklistDTO? Checklist { get; set; }
    }
}