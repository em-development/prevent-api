using Adapters.Context;
using Application.Exceptions.Context;
using DTO.Settings.Users;
using DTO.Tools;

namespace Application.Context
{
    public sealed class SessionContext : ISessionContext
    {
        private string? Token { get; set; }
        public FirebaseIdentityDto? FirebaseIdentity { get; private set; }

        public CompactUserDTO? UserSession { get; private set; }
        public bool HasUser => UserSession != null;

        public void SetUser(CompactUserDTO user)
        {
            if (UserSession != null)
            {
                throw new UserAlreadyExistsInContextException();
            }

            UserSession = user;
        }

        public string? GetToken()
        {
            return Token;
        }

        public void SetToken(string? token)
        {
            Token = token;
        }

        public void SetFirebase(FirebaseIdentityDto firebaseIdentity)
        {
            if (FirebaseIdentity != null)
            {
                throw new UserAlreadyExistsInContextException();
            }

            FirebaseIdentity = firebaseIdentity;
        }

        public void ValidateUserSession()
        {
            if (!HasUser)
            {
                throw new UserNotRegisteredInSessionException();
            }
        }
    }
}