using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;

namespace Repository.Configuration.Context
{
    public class FirestoreDbContext
    {
        public FirestoreDb DB;

        public FirestoreDbContext(IConfiguration configuration)
        {
            string project = configuration.GetSection("Firebase:project_id").Value;

            DB = FirestoreDb.Create(project);
        }
    }
}
