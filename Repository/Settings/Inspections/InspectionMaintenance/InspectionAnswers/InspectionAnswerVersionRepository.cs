using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswerVersionRepository : BaseRepository, IInspectionAnswerVersionRepository
    {
        public InspectionAnswerVersionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<InspectionAnswerVersion?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionAnswerVersions
                .Include(i => i.InspectionAnswer)
                .Include(i => i.AnswerVersion)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InspectionAnswerVersion>> GetByInspectionAnswerId(int inspectionAnswerId)
        {
            return await _dbContext.InspectionAnswerVersions
                .Where(x => x.InspectionAnswerId == inspectionAnswerId)
                .ToListAsync();
        }

        public async Task<InspectionAnswerVersion> InsertAsync(InspectionAnswerVersion entity)
        {
            _dbContext.InspectionAnswerVersions.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionAnswerVersion> UpdateAsync(InspectionAnswerVersion entity)
        {
            _dbContext.InspectionAnswerVersions.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionAnswerVersion entity)
        {
            this._dbContext.InspectionAnswerVersions.Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return;
        }
    }
}
