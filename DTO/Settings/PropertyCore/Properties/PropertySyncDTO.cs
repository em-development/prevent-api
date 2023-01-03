using Domain.Enums.Settings.Properties;

namespace DTO.Settings.PropertyCore.Properties
{
    public class PropertySyncDTO
    {
        public PropertyDTO Corporate { get; set; }
        public PropertyDTO Prevent { get; set; }
        public PropertySyncStatusEnum Status { get; set; }
    }
}