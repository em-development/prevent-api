using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionChecklistsRepository : BaseRepository, IInspectionTemplateVersionChecklistsRepository
    {
        public InspectionTemplateVersionChecklistsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<InspectionTemplateVersionChecklists>> GetByInspectionTemplateVersionId(int inspectionTemplateVersionId)
        {
            return await _dbContext.InspectionTemplateVersionChecklists
                .Where(x => x.InspectionTemplateVersionId == inspectionTemplateVersionId)
                .ToListAsync();
        }

        public async Task<InspectionTemplateVersionChecklists> InsertAsync(InspectionTemplateVersionChecklists entity)
        {
            _dbContext.InspectionTemplateVersionChecklists.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionTemplateVersionChecklists entity)
        {
            _dbContext.InspectionTemplateVersionChecklists.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
