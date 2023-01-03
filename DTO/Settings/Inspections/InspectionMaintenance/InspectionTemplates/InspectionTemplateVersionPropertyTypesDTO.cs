
namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionPropertyTypesDTO
    {
        public int Id { get; set; }
        public InspectionTemplateVersionDTO? InspectionTemplateVersion { get; set; }
        public int PropertyTypeId { get; set; }
    }
}