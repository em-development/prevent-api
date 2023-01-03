using DTO.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using DTO.Settings.PropertyCore.Properties;
using DTO.Settings.Users;

namespace DTO.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionFormDTO
    {
        public int Id { get; set; }
        public PropertyDTO? Property { get; set; }
        public UserDto? Inspector { get; set; }
        public bool IsHighRisk { get; set; }
        public string CoverageBegin { get; set; } = string.Empty;
        public string CoverageEnd { get; set; } = string.Empty;
        public decimal CoveragePremium { get; set; }
        public InspectionTemplateVersionDTO? TemplateVersion { get; set; }
        public int StatusId { get; set; }
        public IList<LegalEntityContactDTO>? Responsables { get; set; }
        public IList<InspectionPropertyBuildingDTO>? Buildings { get; set; }
        public IList<InspectionPropertyCoverageDTO>? PropertyCoverages { get; set; }
        public InspectionScheduleDTO? InspectionSchedule { get; set; }
    }
}