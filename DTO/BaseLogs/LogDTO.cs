
using DTO.Settings.Users;

namespace DTO.BaseLogs
{
    public class LogDTO
    {
        public int Id { get; set; }
        public string SourceEnum { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public UserDto User { get; set; } = new UserDto();
        public DateTime Date { get; set; }
    }
}