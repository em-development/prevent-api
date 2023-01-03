using Adapters.Repositories.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public interface IInspectionTemplateRepository :
        IGetByIdRepository<InspectionTemplate>,
        IInsertRepository<InspectionTemplate>,
        IUpdateRepository<InspectionTemplate>
    {
        IQueryable<InspectionTemplate> SearchToDashboard(
            string? filter,
            string? orderDirection,
            string? orderBy
        );
        IQueryable<InspectionTemplate> SearchToSideForm(
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<InspectionTemplate> SearchByPropertyTypeId(
            int propertyTypeId,
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        Task<InspectionTemplate?> GetByIdWithVersions(int id);
    }
}
