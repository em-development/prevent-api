using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionResponsableRepository : BaseRepository, IInspectionResponsableRepository
    {
        public InspectionResponsableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<InspectionResponsable?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionResponsables
                .Include(i => i.LegalEntityContact)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InspectionResponsable>> GetByInspectionId(int inspectionId)
        {
            return await _dbContext.InspectionResponsables
                .Where(x => x.InspectionId == inspectionId)
                .ToListAsync();
        }

        public async Task<InspectionResponsable> InsertAsync(InspectionResponsable entity)
        {
            _dbContext.InspectionResponsables.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionResponsable> UpdateAsync(InspectionResponsable entity)
        {
            _dbContext.InspectionResponsables.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionResponsable entity)
        {
            this._dbContext.InspectionResponsables.Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return;
        }
    }
}
