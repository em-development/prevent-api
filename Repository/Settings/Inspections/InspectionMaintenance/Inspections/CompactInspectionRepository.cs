using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Compacts.Settings.Inspections;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Configuration.Context;

namespace Repository.Settings.Inspections.InspectionMaintenance.Inspections
{
    public sealed class CompactInspectionRepository : BaseRepository, ICompactInspectionRepository
    {
        public CompactInspectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CompactInspection?> GetByIdAsync(int id)
        {
            return await _dbContext.CompactInspections.FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<CompactInspection> SearchToDashboard(
            string? filter = null,
            string? orderDirection = "asc",
            string? orderBy = null,
            int? inspectorId = null
        )
        {
            var query = _dbContext.CompactInspections
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query
                    .Where(i => i.Description.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderDirection) && orderDirection == "asc")
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "name")
                {
                    query = query.OrderBy(i => i.Description);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(orderBy) && orderBy == "name")
                {
                    query = query.OrderByDescending(i => i.Description);
                }
            }

            if (inspectorId != null)
            {
                query = query.Where(i => i.UserId == inspectorId);
            }

            return query;
        }
    }
}