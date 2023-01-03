using Adapters.Repositories.Base;
using Domain.Entities.Settings.PropertyCore.Properties;

namespace Adapters.Repositories.Settings.PropertyCore.Properties
{
    public interface IPropertyRepository :
        IGetByIdRepository<Property>,
        IInsertRepository<Property>,
        IUpdateRepository<Property>
    {
        IQueryable<Property> SearchToDashboard(
            string? filter,
            int current,
            int limit,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<Property> SearchByLegalEntityId(
            int legalEntityId,
            string? filter,
            int current,
            int limit,
            string? orderDirection,
            string? orderBy
        );

        Task<IEnumerable<PropertyType>> GetPropertyTypes();

        IQueryable<Property> GetAllProperties(string? filter = null);

        Task<IEnumerable<int>?> GetByInspectionTemplateVersionId(int id);
    }
}