using Domain.Enums.Settings.Entities;

namespace DTO.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntitySyncDTO
    {
        public LegalEntityDTO? Corporate { get; set; }
        public LegalEntityDTO? Prevent { get; set; }
        public LegalEntitySyncStatusEnum Status { get; set; }
    }
}