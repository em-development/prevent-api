using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.ValueObjects.Inspections.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    internal class InspectionMapping : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CoveragePremium)
                .HasColumnType("decimal(18,2)");

            builder.OwnsOne(x => x.CoverageBegin)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(CoverageBegin))
                    .HasMaxLength(CoverageBegin.FieldMaxLength)
                    .HasColumnType("varchar");

            builder.OwnsOne(x => x.CoverageEnd)
                   .Property(x => x.Value)
                   .HasColumnName(nameof(CoverageEnd))
                   .HasMaxLength(CoverageEnd.FieldMaxLength)
                   .HasColumnType("varchar");

            builder.HasOne(x => x.Property)
                .WithMany(x => x.Inspections)
                .HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Inspector)
                .WithMany(x => x.Inspections)
                .HasForeignKey(x => x.InspectorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.InspectionTemplateVersion)
                .WithMany(x => x.Inspections)
                .HasForeignKey(x => x.TemplateVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.InspectionStatus)
                .WithMany(x => x.Inspections)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Inspections", "settings");

        }
    }
}
