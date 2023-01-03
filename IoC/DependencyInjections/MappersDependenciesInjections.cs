using Application.Mappings.Exception;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.DependencyInjections
{
    internal static class MappersDependenciesInjections
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ExceptionMapping).Assembly);

            return services;
        }
    }
}
