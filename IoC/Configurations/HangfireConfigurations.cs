using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.JobsLogger;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Configurations;

public static class HangfireConfigurations
{
    public static IServiceCollection AddHangfireConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddHangfire(options =>
        {
            options.UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("SqlConnectionString"),
                    new SqlServerStorageOptions
                    {
                        SchemaName = "jobs",
                        DisableGlobalLocks = true
                    })
                .UseJobsLogger()
                .UseConsole();
        });

        services.AddHangfireServer();

        services.AddHostedService<JobsSchedules>();

        return services;
    }

    public class MyAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }

    public static WebApplication UseHangfireConfiguration(this WebApplication app)
    {
        var dashboardOptions = new DashboardOptions()
        {
            Authorization = new[] {new MyAuthorizationFilter()}
        };

        app.UseHangfireDashboard("/dashboard", dashboardOptions);
        return app;
    }
}