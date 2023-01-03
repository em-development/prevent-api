using Microsoft.Extensions.DependencyInjection;

namespace IoC.Configurations
{
    public static class CorsPolicyConfiguration
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();

                builder.WithExposedHeaders(new[] {
                    "X-Custom-Header",
                    "Location",
                    "Content-Disposition",
                    "Content-Length",
                });
            }));
            return services;
        }
    }
}
