using Adapters.Repositories.Inspections.Inspections;
using Domain.Entities.Inspections.Inspections;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Inspections.Inspections;

public class InspectionAttachmentRepository : BaseRepository, IInspectionAttachmentRepository
{
    public InspectionAttachmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<InspectionAttachment?> GetByIdAsync(int id)
    {
        return await _dbContext.InspectionAttachments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<InspectionAttachment> InsertAsync(InspectionAttachment entity)
    {
        _dbContext.InspectionAttachments.Add(entity);

        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task RemoveAsync(InspectionAttachment entity)
    {
        _dbContext.InspectionAttachments.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<InspectionAttachment>> ListByInspectionId(int inspectionId)
    {
        return await _dbContext.InspectionAttachments
            .Where(ia => ia.InspectionId == inspectionId)
            .Include(ia => ia.Attachment)
            .ToListAsync();
    }
}