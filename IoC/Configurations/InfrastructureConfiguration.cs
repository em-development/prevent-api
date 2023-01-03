using IoC.DependencyInjections;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Configurations
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddConfigOptions(configuration)
                .AddInjections(configuration)
                .AddDatabase(configuration)
                .AddCorsPolicy()
                .AddAPIAuthentication(configuration)
                .AddApiSwagger(configuration)
                .AddMediatRConfig()
                .AddHangfireConfiguration(configuration);

            return services;
        }

        public static WebApplication UseInfrastructure(
            this WebApplication app,
            IConfiguration configuration)
        {
            app.UseHangfireConfiguration();
            app.UseApiSwaggerConfiguration(configuration);
            return app;
        }
    }
}