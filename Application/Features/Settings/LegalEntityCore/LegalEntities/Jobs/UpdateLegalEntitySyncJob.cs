using Adapters.Services.Settings.LegalEntities;
using Application.Features.Settings.PropertyCore.Properties.Jobs;
using Hangfire;
using Hangfire.Server;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Jobs;

public class UpdateLegalEntitySyncJob
{
    private readonly ILegalEntitySyncService _legalEntitySyncService;
    
    public UpdateLegalEntitySyncJob(
        ILegalEntitySyncService legalEntitySyncService)
    {
        _legalEntitySyncService = legalEntitySyncService;
    }

    [DisableConcurrentExecution(10)]
    [AutomaticRetry(Attempts = 0)]
    [JobDisplayName("Sync Legal Entities")]
    public async Task Run(PerformContext? context)
    {
        Console.WriteLine("========== Starting Sync Legal Entities! =======");
        
        await _legalEntitySyncService.SyncLegalEntities();
        
        BackgroundJob.ContinueJobWith<UpdatePropertySyncJob>(context?.BackgroundJob.Id, x => x.Run(null));
    }
}