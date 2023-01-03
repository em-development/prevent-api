using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.ValueObjects.Settings.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    internal class InspectionPropertyBuildingMapping : IEntityTypeConfiguration<InspectionPropertyBuilding>
    {
        public void Configure(EntityTypeBuilder<InspectionPropertyBuilding> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                .Property(x => x.Value)
                .HasColumnName(nameof(InspectionPropertyBuildingDescription))
                .HasMaxLength(InspectionPropertyBuildingDescription.FieldMaxLength)
                .HasColumnType("varchar");

            builder.OwnsOne(x => x.BuildingPattern)
                .Property(x => x.Value)
                .HasColumnName(nameof(BuildingPattern))
                .HasMaxLength(BuildingPattern.FieldMaxLength)
                .HasColumnType("varchar");

            builder.Property(x => x.BuildingPatternRate)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Measures)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Inspection)
                .WithMany(x => x.InspectionPropertyBuildings)
                .HasForeignKey(x => x.InspectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("InspectionPropertyBuildings", "settings");

        }
    }
}
