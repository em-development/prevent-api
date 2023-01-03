using Adapters.Services.Settings.Properties;
using Hangfire;
using Hangfire.Server;

namespace Application.Features.Settings.PropertyCore.Properties.Jobs;

public class UpdatePropertySyncJob
{
    private readonly IPropertySyncService _propertySyncService;
    public UpdatePropertySyncJob(
        IPropertySyncService propertySyncService
        )
    {
        _propertySyncService = propertySyncService;
    }

    [DisableConcurrentExecution(10)]
    [AutomaticRetry(Attempts = 0)]
    [JobDisplayName("Sync Properties")]
    public async Task Run(PerformContext? context)
    {
        Console.WriteLine("========== Starting Sync Properties! =======");

        await _propertySyncService.SyncProperties();
    }
}