using DTO.Settings.Users;

namespace Adapters.Services.Settings.Users
{
    public interface IUserService
    {
        Task<CompactUserDTO?> GetBySubjectIdAsync(string subjectId);
        Task<CompactUserDTO?> GetByEmailAsync(string email);
    }
}
