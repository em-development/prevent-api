using Domain.Enums.Settings.Users;

namespace DTO.Settings.Users
{
    public class UserFormDto : UserDto
    {
        public IEnumerable<int> LegalEntityIds { get; set; } = new List<int>();
        public IEnumerable<int> UserProfileIds { get; set; } = new List<int>();
    }
}