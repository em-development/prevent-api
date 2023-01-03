using DTO.Settings.LegalEntityCore.LegalEntities;

namespace DTO.Settings.LegalEntityCore.LegalEntityContacts
{
    public class LegalEntityContactDTO
    {
        public int Id { get; set; }
        public LegalEntityDTO? LegalEntity { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Type { get; set; }
    }
}