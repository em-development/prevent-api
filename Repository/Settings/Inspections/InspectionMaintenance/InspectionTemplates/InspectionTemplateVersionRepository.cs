using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionRepository : BaseRepository, IInspectionTemplateVersionRepository
    {
        public InspectionTemplateVersionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<InspectionTemplateVersion>?> GetByInspectionTemplateId(int inspectionTemplateId)
        {
            return await _dbContext.InspectionTemplateVersions
                .Where(x => x.InspectionTemplateId == inspectionTemplateId)
                .ToListAsync();
        }

        public async Task<InspectionTemplateVersion?> GetByIdWithChecklistsAndQuestions(int id)
        {
#pragma warning disable CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
            return await _dbContext.InspectionTemplateVersions
#pragma warning restore CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
                .Include(i => i.InspectionTemplateVersionChecklists)
                .ThenInclude(i => i.Checklist)
                .ThenInclude(i => i.Version)
                .ThenInclude(i => i.ChecklistVersionQuestions)
                .ThenInclude(i => i.Question)
                .ThenInclude(i => i.Version)
                .FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<InspectionTemplateVersion> InsertAsync(InspectionTemplateVersion entity)
        {
            _dbContext.InspectionTemplateVersions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionTemplateVersion entity)
        {
            _dbContext.InspectionTemplateVersions.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
