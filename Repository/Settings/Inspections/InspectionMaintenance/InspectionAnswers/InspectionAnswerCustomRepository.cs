using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswerCustomRepository : BaseRepository, IInspectionAnswerCustomRepository
    {
        public InspectionAnswerCustomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<InspectionAnswerCustom?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionAnswerCustoms
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InspectionAnswerCustom>> GetByInspectionAnswerId(int inspectionAnswerId)
        {
            return await _dbContext.InspectionAnswerCustoms
                .Where(x => x.InspectionAnswerId == inspectionAnswerId)
                .ToListAsync();
        }

        public async Task<InspectionAnswerCustom> InsertAsync(InspectionAnswerCustom entity)
        {
            _dbContext.InspectionAnswerCustoms.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionAnswerCustom> UpdateAsync(InspectionAnswerCustom entity)
        {
            _dbContext.InspectionAnswerCustoms.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionAnswerCustom entity)
        {
            this._dbContext.InspectionAnswerCustoms.Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return;
        }
    }
}
