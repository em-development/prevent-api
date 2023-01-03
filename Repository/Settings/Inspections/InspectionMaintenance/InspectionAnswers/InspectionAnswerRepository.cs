using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswerRepository : BaseRepository, IInspectionAnswerRepository
    {
        public InspectionAnswerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<InspectionAnswer?> GetByIdAsync(int id)
        {
            return await _dbContext.InspectionAnswers
                .Include(i => i.ChecklistVersion)
                .ThenInclude(i => i.ChecklistVersionQuestions)
                .Include(i => i.QuestionVersion)
                .Include(i => i.InspectionAnswerCustoms)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InspectionAnswer>> GetByInspectionId(int inspectionId)
        {
            return await _dbContext.InspectionAnswers
                .Where(x => x.InspectionId == inspectionId)
                .ToListAsync();
        }

        public async Task<InspectionAnswer> InsertAsync(InspectionAnswer entity)
        {
            _dbContext.InspectionAnswers.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<InspectionAnswer> UpdateAsync(InspectionAnswer entity)
        {
            _dbContext.InspectionAnswers.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(InspectionAnswer entity)
        {
            this._dbContext.InspectionAnswers.Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return;
        }
    }
}
