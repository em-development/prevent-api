using Domain.Enums.Settings.Entities;
using DTO.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.PropertyCore.Properties;

namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionDTO
    {
        public int Id { get; set; }
        public int InspectionTemplateId { get; set; }
        public int Version { get; set; }
        public string Title { get; set; } = string.Empty;
        public IEnumerable<ChecklistVersionDTO>? Checklists { get; set; }
        public IEnumerable<PropertyTypeEnum>? PropertyTypes { get; set; }
    }
}