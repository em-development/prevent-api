using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.ValueObjects.Inspections.InspectionsPropertyCoverages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    internal class InspectionPropertyCoverageMapping : IEntityTypeConfiguration<InspectionPropertyCoverage>
    {
        public void Configure(EntityTypeBuilder<InspectionPropertyCoverage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .HasColumnType("decimal(18,2)");

            builder.OwnsOne(x => x.Coverage)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Coverage))
                    .HasMaxLength(Coverage.FieldMaxLength)
                    .HasColumnType("varchar");

            builder.HasOne(x => x.Inspection)
                .WithMany(x => x.InspectionPropertyCoverages)
                .HasForeignKey(x => x.InspectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("InspectionPropertyCoverages", "settings");

        }
    }
}
