using DTO.Settings.LegalEntityCore.LegalEntities;

namespace DTO.Settings.PropertyCore.Properties
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int PropertyTypeId { get; set; }
        public bool Status { get; set; }
        public LegalEntityDTO? LegalEntity { get; set; }
        public object? LegalEntityCore { get; set; }
    }
}