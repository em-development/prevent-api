using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.DependencyInjections
{
    internal static class DependenciesInjections
    {
        internal static IServiceCollection AddInjections(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddMapper()
                .AddTransaction()
                .AddContexts()
                .AddRepositories()
                .AddServices(configuration);

            return services;
        }
    }
}