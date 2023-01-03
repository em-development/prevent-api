using Adapters.Context;
using Application.Context;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.DependencyInjections
{
    internal static class ContextsDependenciesInjections
    {
        public static IServiceCollection AddContexts(this IServiceCollection services)
        {
            services.AddScoped<ISessionContext, SessionContext>();
            return services;
        }
    }
}
