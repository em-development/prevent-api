using Adapters.Context;
using Google.Cloud.Firestore;
using Repository.Configuration.Context;

namespace Repository.Base
{
    public abstract class FirestoreBaseRepository
    {
        protected readonly FirestoreDb _dbContext;

        public CollectionReference Collection { get; set; }

        protected FirestoreBaseRepository(
            FirestoreDbContext dbContext,
            ISessionContext sessionContext,
            string path
        )
        {
            _dbContext = dbContext.DB;

            if (sessionContext?.UserSession != null)
            {
                path = $"{path.Trim('/').TrimEnd('/')}/{sessionContext.UserSession.IdAsSecret}";

                Collection = dbContext.DB.Collection(path);
            }
            else
            {
                Collection = dbContext.DB.Collection("core");
            }
        }
    }
}
