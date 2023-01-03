using Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.LegalEntityCore.LegalEntityContacts
{
    public class LegalEntityContactRepository : BaseRepository, ILegalEntityContactRepository
    {
        public LegalEntityContactRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LegalEntityContact?> GetByIdAsync(int id)
        {
            return await _dbContext.LegalEntityContacts
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        async Task<IEnumerable<LegalEntityContact>> ILegalEntityContactRepository.GetByLegalEntityId(int legalEntityId)
        {
            return await _dbContext.LegalEntityContacts
                .Where(x => x.LegalEntityId == legalEntityId)
                .ToListAsync();
        }
        
        public async Task<LegalEntityContact> InsertAsync(LegalEntityContact entity)
        {
            this._dbContext.LegalEntityContacts.Add(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<LegalEntityContact> UpdateAsync(LegalEntityContact entity)
        {
            this._dbContext.LegalEntityContacts.Update(entity);

            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task RemoveAsync(LegalEntityContact entity)
        {
            this._dbContext.LegalEntityContacts.Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return;
        }

    }
}