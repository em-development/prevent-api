
namespace DTO.Settings.Inspections.InspectionMaintenance.Inspections
{
    public sealed class CompactInspectionDTO
    {
        public int Id { get; set; }
        public int TemplateVersionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string LegalEntity { get; set; } = string.Empty;
        public string CodeEntity { get; set; } = string.Empty;
        public string PropertyType { get; set; } = string.Empty;
        public int InspectionStatus { get; set; }
        public decimal FillStatus { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
