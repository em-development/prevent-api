using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IoC.Configurations
{
    public static class SwaggerConfiguration
    {
        internal static IServiceCollection AddApiSwagger(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (IsEnvironmentEnabled(configuration))
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo {Title = "ARMS Prevent", Version = "v1"});
                    c.TryIncludeXmlComments();
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme()
                            {
                                Reference = new OpenApiReference()
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                });
            }

            return services;
        }

        public static WebApplication UseApiSwaggerConfiguration(
            this WebApplication app,
            IConfiguration configuration)
        {
            if (!configuration.GetSection("Swagger:Enabled").Get<bool>()) return app;

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ARMS Prevent V1"); });

            return app;
        }

        private static SwaggerGenOptions TryIncludeXmlComments(this SwaggerGenOptions c)
        {
            try
            {
                var xmlPath = GetXmlPath();
                c.IncludeXmlComments(xmlPath);
            }
            catch
            {
                Console.WriteLine("Xml not found, swagger docstring will be no get");
            }

            return c;
        }

        private static string GetXmlPath()
        {
            return Assembly.GetEntryAssembly()?.Location.Replace("dll", "xml") ??
                   "/app/bin/Debug/net6.0/CC.Api.xml";
        }

        private static bool IsEnvironmentEnabled(IConfiguration configuration)
        {
            try
            {
                return configuration.GetSection("Swagger:Enabled").Get<bool>();
            }
            catch
            {
                return false;
            }
        }
    }
}