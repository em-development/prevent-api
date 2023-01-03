using DTO.Settings.LegalEntityCore.LegalEntities;

namespace DTO.Settings.PropertyCore.Properties
{
    public class PropertyCorporateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Code { get; set; } = String.Empty;
        public int PropertyTypeId { get; set; }
        public LegalEntityDTO? LegalEntity { get; set; }
    }
}