using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Features.Settings.Users.Queries.GetUser;

namespace IoC.Configurations
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetUserHandler).GetTypeInfo().Assembly);
            return services;
        }
    }
}
