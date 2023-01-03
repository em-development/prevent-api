namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateDTO
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}