using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IoC.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAPIAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = configuration["FirebaseTokenValidation:Authority"];
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidIssuer = configuration["FirebaseTokenValidation:ValidIssuer"],
                            ValidateAudience = true,
                            ValidAudience = configuration["FirebaseTokenValidation:Audience"],
                            ValidateLifetime = true
                        };
                    });

            return services;
        }
    }
}
