using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository.Configuration.Context;

namespace IoC.Configurations
{
    internal static class DatabaseConfiguration
    {
        internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information));

            services.AddSingleton<FirestoreDbContext>();

            return services;
        }
    }
}
