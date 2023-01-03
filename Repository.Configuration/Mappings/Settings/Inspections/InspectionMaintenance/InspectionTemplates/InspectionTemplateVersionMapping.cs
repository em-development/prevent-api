using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.ValueObjects.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    internal class InspectionTemplateVersionMapping : IEntityTypeConfiguration<InspectionTemplateVersion>
    {
        public void Configure(EntityTypeBuilder<InspectionTemplateVersion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Title)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Title))
                    .HasMaxLength(Title.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.HasOne(x => x.InspectionTemplate)
                .WithMany(x => x.InspectionTemplateVersions)
                .HasForeignKey(x => x.InspectionTemplateId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("InspectionTemplateVersion", "settings");
        }
    }
}
