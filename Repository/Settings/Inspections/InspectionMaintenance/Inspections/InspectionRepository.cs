using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionRepository : BaseRepository, IInspectionRepository
    {
        public InspectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<Inspection?> GetByIdAsync(int id)
        {
            return await _dbContext.Inspections
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inspection?> GetByIdWithIncludesAsync(int id)
        {
            return await _dbContext.Inspections
                .Include(i => i.InspectionResponsables)!
                .ThenInclude(i => i.LegalEntityContact)
                .Include(i => i.InspectionPropertyBuildings)
                .Include(i => i.InspectionPropertyCoverages)
                .Include(i => i.InspectionTemplateVersion)
                .Include(i => i.Property)
                .ThenInclude(i => i!.LegalEntity)
                .Include(i => i.Inspector)
                .Include(i => i.InspectionSchedule)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<Inspection> SearchToDashboard(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null
        )
        {
            var query = _dbContext.Inspections
                .Include(i => i.InspectionResponsables)
                .Include(i => i.InspectionPropertyBuildings)
                .Include(i => i.InspectionPropertyCoverages)
                .Include(i => i.InspectionTemplateVersion)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query
                    .Where(i => i.Property != null && i.Property.Name.Value.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderDirection) && orderDirection == "asc")
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "name")
                {
                    query = query.OrderBy(i => i.Property != null ? i.Property.Name.Value : null);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "name")
                {
                    query = query.OrderByDescending(i => i.Property != null ? i.Property.Name.Value : null);
                }
            }

            return query;
        }

        public async Task<Inspection?> GetById(int id)
        {

            return await _dbContext.Inspections
                .Include(i => i.InspectionTemplateVersion)
                .Include(i => i.InspectionResponsables)
                .Include(i => i.InspectionPropertyBuildings)
                .Include(i => i.InspectionPropertyCoverages)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inspection> InsertAsync(Inspection entity)
        {
            _dbContext.Inspections.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Inspection> UpdateAsync(Inspection entity)
        {
            _dbContext.Inspections.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}