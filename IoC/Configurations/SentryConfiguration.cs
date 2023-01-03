using Domain.Exceptions.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace IoC.Configurations;

public static class SentryConfiguration
{
    public static ConfigureWebHostBuilder AddSentryConfiguration(
        this ConfigureWebHostBuilder webHost)
    {
        webHost.UseSentry(options =>
        {
            options.BeforeSend = @event =>
            {
                if (@event.Environment == "Local"
                    || @event.Exception is BaseException
                    || (@event.TransactionName != null
                        && @event.TransactionName.Contains("_healthcheck/status")))
                {
                    return null;
                }

                return @event;
            };
        });

        return webHost;
    }
}