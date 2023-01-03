using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections
{
    public interface IInspectionRepository :
        IGetByIdRepository<Inspection>,
        IInsertRepository<Inspection>,
        IUpdateRepository<Inspection>
    {
        Task<Inspection?> GetByIdWithIncludesAsync(int id);

        IQueryable<Inspection> SearchToDashboard(
            string? filter,
            string? orderDirection,
            string? orderBy
        );
    }
}
