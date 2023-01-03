using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public class InspectionPropertyBuildingRepository : BaseRepository, IInspectionPropertyBuildingRepository
    {
        public InspectionPropertyBuildingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<InspectionPropertyBuilding?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionPropertyBuildings
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InspectionPropertyBuilding>> GetByInspectionId(int inspectionId)
        {
            return await _dbContext.InspectionPropertyBuildings
                .Where(x => x.InspectionId == inspectionId)
                .ToListAsync();
        }

        public async Task<InspectionPropertyBuilding> InsertAsync(InspectionPropertyBuilding entity)
        {
            _dbContext.InspectionPropertyBuildings.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionPropertyBuilding> UpdateAsync(InspectionPropertyBuilding entity)
        {
            _dbContext.InspectionPropertyBuildings.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionPropertyBuilding entity)
        {
            this._dbContext.InspectionPropertyBuildings.Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return;
        }
    }
}
