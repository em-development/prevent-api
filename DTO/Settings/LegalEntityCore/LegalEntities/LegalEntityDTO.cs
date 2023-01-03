using Domain.Enums.Settings.Entities;

namespace DTO.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CodeEntity { get; set; } = string.Empty;
        public bool Status { get; set; }
        public LegalEntityTypeEnum TypeId { get; set; }
        public LegalEntityDTO? Parent { get; set; }
    }
}