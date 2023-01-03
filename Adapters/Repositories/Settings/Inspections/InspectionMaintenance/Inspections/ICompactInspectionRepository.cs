using Adapters.Repositories.Base;
using Domain.Compacts.Settings.Inspections;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections
{
    public interface ICompactInspectionRepository :
        IGetByIdRepository<CompactInspection>
    {
        IQueryable<CompactInspection> SearchToDashboard(
            string? filter,
            string? orderDirection,
            string? orderBy,
            int? inspectorId = null
        );
    }
}