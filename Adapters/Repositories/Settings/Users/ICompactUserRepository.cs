using Domain.Compacts.Settings.Users;

namespace Adapters.Repositories.Settings.Users
{
    public interface ICompactUserRepository
    {
        Task<CompactUser?> GetBySubjectIdAsync(string subjectId);
        Task<CompactUser?> GetByEmailAsync(string email);
    }
}
