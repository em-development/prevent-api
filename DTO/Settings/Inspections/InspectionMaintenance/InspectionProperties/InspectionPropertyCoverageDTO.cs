using DTO.Settings.Inspections.InspectionMaintenance.Inspections;

namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public class InspectionPropertyCoverageDTO
    {
        public int Id { get; set; }
        public InspectionDTO? Inspection { get; set; }
        public int CoverageId { get; set; }
        public string Coverage { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}