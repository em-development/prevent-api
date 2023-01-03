using Adapters.Services.BaseLogs;
using Adapters.Services.Core.Menus;
using Adapters.Services.Files;
using Adapters.Services.Settings.LegalEntities;
using Adapters.Services.Settings.Properties;
using Adapters.Services.Settings.Users;
using Amazon.Runtime;
using Amazon.S3;
using Application.Services.Core.Menus;
using Application.Services.Files;
using Application.Services.Settings.LegalEntities;
using Application.Services.Settings.Properties;
using Application.Services.Settings.Users;
using CC.Application.Services.BaseLogs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.DependencyInjections
{
    internal static class ServicesDependenciesInjections
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var config = new AmazonS3Config();

            services.AddScoped<IUserService, UserService>()
                .AddScoped<ILegalEntitySyncService, LegalEntitySyncService>()
                .AddScoped<IPropertySyncService, PropertySyncService>()
                .AddScoped<ILogService, LogService>()
                .AddScoped<IAmazonS3>(_ =>
                {
                    AWSCredentials credentials = new BasicAWSCredentials(
                        configuration.GetSection("S3:AccessKey").Value,
                        configuration.GetSection("S3:KeySecret").Value);

                    config.RegionEndpoint =
                        Amazon.RegionEndpoint.GetBySystemName(configuration.GetSection("S3:Endpoint").Value);

                    return new AmazonS3Client(credentials, config);
                })
                .AddScoped<IFileStorageService, AwsFileStorageService>()
                .AddScoped<IMenuService, MenuService>();

            return services;
        }
    }
}