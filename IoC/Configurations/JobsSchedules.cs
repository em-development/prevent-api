using Application.Features.Settings.LegalEntityCore.LegalEntities.Jobs;
using Hangfire;
using Microsoft.Extensions.Hosting;

namespace IoC.Configurations;

public class JobsSchedules : IHostedService
{
    private readonly BackgroundJobServer _jobServer;
    private static IHostEnvironment? _environment;

    public JobsSchedules(IHostEnvironment environment)
    {
        _environment = environment;
        _jobServer = new BackgroundJobServer();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        var result = Task.Run(() =>
        {
            if (_ToRunIn(local:false, staging:true, production:true))
            {
                RecurringJob.AddOrUpdate<UpdateLegalEntitySyncJob>("Sync Legal Entities", x => x.Run(null), "* 2 * * *",
                    timeZone);
            }
            
            if (_ToRunIn(local:false))
            {
                BackgroundJob.Enqueue<UpdateLegalEntitySyncJob>(x => x.Run(null));
            }
            
        }, cancellationToken);

        await result;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        var result = Task.Run(() =>
        {
            Console.WriteLine("Send stop signal to jobServer.");
            _jobServer.SendStop();
            Console.WriteLine("Wait 1 second.");
            Thread.Sleep(1000);
            _jobServer.Dispose();
        }, cancellationToken);

        await result;
    }

    private static bool _ToRunIn(bool local = false, bool staging = false, bool production = false)
    {
        if (_environment == null)
        {
            return false;
        }

        return _environment.EnvironmentName switch
        {
            "Local" => local,
            "Staging" => staging,
            "production" => production,
            _ => false
        };
    }
}