using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionScheduleRepository : BaseRepository, IInspectionScheduleRepository
    {
        public InspectionScheduleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<InspectionSchedule?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionSchedules
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<InspectionSchedule?> GetById(int id)
        {
#pragma warning disable CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
            return await _dbContext.InspectionSchedules
#pragma warning restore CS8620 // O argumento não pode ser usado para o parâmetro devido a diferenças na nulidade dos tipos de referência.
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<InspectionSchedule> InsertAsync(InspectionSchedule entity)
        {
            _dbContext.InspectionSchedules.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionSchedule> UpdateAsync(InspectionSchedule entity)
        {
            _dbContext.InspectionSchedules.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}