using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Configurations
{
    internal static class OptionsConfiguration
    {
        public static IServiceCollection AddConfigOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<MailClientOptionsDto>(configuration.GetSection("EmailSenderClient"))
            //        .Configure<SourceOptionsDto>(configuration.GetSection("Source"));
            return services;
        }
    }
}
