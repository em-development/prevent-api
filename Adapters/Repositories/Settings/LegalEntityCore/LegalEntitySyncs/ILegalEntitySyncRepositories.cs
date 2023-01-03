using Adapters.Repositories.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;

namespace Adapters.Repositories.Settings.LegalEntityCore.LegalEntitySyncs
{
    public interface ILegalEntitySyncRepository :
        IGetByIdRepository<LegalEntitySync>,
        IInsertRepository<LegalEntitySync>,
        IUpdateRepository<LegalEntitySync>
    {
        IQueryable<LegalEntitySync> SearchToDashboard(
            string? filter,
            int current,
            int limit,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<LegalEntitySync> GetAllLegalEntities();
        
        IQueryable<LegalEntitySync> GetAllLegalEntities(string? filter);
    }
}