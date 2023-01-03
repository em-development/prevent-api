using Domain.Enums.Settings.Entities;

namespace DTO.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntityCorporateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeEntity { get; set; }
        public bool Status { get; set; }
        public LegalEntityTypeEnum TypeEnum { get; set; }
        public LegalEntityDTO? Parent { get; set; }
    }
}