using DTO.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;

namespace DTO.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionDTO
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int InspectorId { get; set; }
        public bool IsHighRisk { get; set; }
        public string CoverageBegin { get; set; } = string.Empty;
        public string CoverageEnd { get; set; } = string.Empty;
        public decimal CoveragePremium { get; set; }
        public int TemplateVersionId { get; set; }
        public int StatusId { get; set; }
        public IList<LegalEntityContactDTO>? Responsables { get; set; }
        public IList<InspectionPropertyBuildingDTO>? Buildings { get; set; }
        public IList<InspectionPropertyCoverageDTO>? PropertyCoverages { get; set; }
        public InspectionScheduleDTO? InspectionSchedule { get; set; }
    }
}