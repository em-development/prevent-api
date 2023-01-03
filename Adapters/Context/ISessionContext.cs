using DTO.Settings.Users;
using DTO.Tools;

namespace Adapters.Context
{
    public interface ISessionContext
    {
        FirebaseIdentityDto? FirebaseIdentity { get; }
        CompactUserDTO? UserSession { get; }
        bool HasUser { get; }

        void ValidateUserSession();
        void SetFirebase(FirebaseIdentityDto firebaseIdentity);
        void SetUser(CompactUserDTO user);

        string? GetToken();
        void SetToken(string? token);
    }
}