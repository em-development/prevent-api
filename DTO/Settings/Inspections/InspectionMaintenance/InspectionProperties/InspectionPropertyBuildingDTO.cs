
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;

namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public class InspectionPropertyBuildingDTO
    {
        public int Id { get; set; }
        public InspectionDTO? Inspection { get; set; }
        public decimal Measures { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BuildingPattern { get; set; } = string.Empty;
        public decimal BuildingPatternRate { get; set; }
    }
}