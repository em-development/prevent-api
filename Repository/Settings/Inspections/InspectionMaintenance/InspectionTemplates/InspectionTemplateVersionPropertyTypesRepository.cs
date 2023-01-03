using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionPropertyTypesRepository : BaseRepository, IInspectionTemplateVersionPropertyTypesRepository
    {
        public InspectionTemplateVersionPropertyTypesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<InspectionTemplateVersionPropertyTypes?>> GetByInspectionTemplateVersionId(int inspectionTemplateVersionId)
        {
            return await _dbContext.InspectionTemplateVersionPropertyTypes
                .Where(x => x.InspectionTemplateVersionId == inspectionTemplateVersionId)
                .ToListAsync();
        }

        public async Task<InspectionTemplateVersionPropertyTypes> InsertAsync(InspectionTemplateVersionPropertyTypes entity)
        {
            _dbContext.InspectionTemplateVersionPropertyTypes.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionTemplateVersionPropertyTypes entity)
        {
            _dbContext.InspectionTemplateVersionPropertyTypes.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
