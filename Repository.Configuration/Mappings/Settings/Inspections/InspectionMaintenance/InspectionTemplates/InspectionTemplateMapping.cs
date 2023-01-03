using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    internal class InspectionTemplateMapping : IEntityTypeConfiguration<InspectionTemplate>
    {
        public void Configure(EntityTypeBuilder<InspectionTemplate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Version)
                .WithMany()
                .HasForeignKey(x => x.VersionId);

            builder.ToTable("InspectionTemplates", "settings");

        }
    }
}
