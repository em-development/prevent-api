using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public class InspectionPropertyCoverageRepository : BaseRepository, IInspectionPropertyCoverageRepository
    {
        public InspectionPropertyCoverageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<InspectionPropertyCoverage?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionPropertyCoverages
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InspectionPropertyCoverage>> GetByInspectionId(int inspectionId)
        {
            return await _dbContext.InspectionPropertyCoverages
                .Where(x => x.InspectionId == inspectionId)
                .ToListAsync();
        }

        public async Task<InspectionPropertyCoverage> InsertAsync(InspectionPropertyCoverage entity)
        {
            _dbContext.InspectionPropertyCoverages.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionPropertyCoverage> UpdateAsync(InspectionPropertyCoverage entity)
        {
            _dbContext.InspectionPropertyCoverages.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionPropertyCoverage entity)
        {
            this._dbContext.InspectionPropertyCoverages.Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return;
        }
    }
}
