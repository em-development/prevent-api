using Adapters.Repositories.Files;
using Adapters.Services.Files;
using Domain.Entities.Files;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AttachmentRepository : BaseRepository, IAttachmentRepository
    {

        public AttachmentRepository(
            ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Attachment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Attachment> InsertAsync(Attachment entity)
        {
            this._dbContext.Attachments.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Attachment> UpdateAsync(Attachment entity)
        {
            this._dbContext.Attachments.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
