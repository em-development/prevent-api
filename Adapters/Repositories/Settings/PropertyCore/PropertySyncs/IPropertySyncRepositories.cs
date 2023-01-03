using Adapters.Repositories.Base;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;

namespace Adapters.Repositories.Settings.PropertyCore.PropertySyncs
{
    public interface IPropertySyncRepository :
        IGetByIdRepository<PropertySync>,
        IInsertRepository<PropertySync>,
        IUpdateRepository<PropertySync>
    {
        IQueryable<PropertySync> SearchToDashboard(
            string? filter,
            int current,
            int limit,
            string? orderDirection,
            string? orderBy,
            bool onlyDifferent
        );

        IQueryable<PropertySync> GetAllProperties();

        IQueryable<PropertySync> GetAllProperties(string filter);
    }
}