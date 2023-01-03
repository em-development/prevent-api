using Domain.Compacts.Settings.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    public sealed class InspectionCompactMapping : IEntityTypeConfiguration<CompactInspection>
    {
        public void Configure(EntityTypeBuilder<CompactInspection> builder)
        {
            builder.HasNoKey();

            builder.ToView("vw_Inspections", "settings");
        }
    }
}
