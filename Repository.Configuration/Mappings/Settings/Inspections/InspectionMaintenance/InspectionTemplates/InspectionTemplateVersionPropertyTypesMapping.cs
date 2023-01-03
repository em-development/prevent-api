using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    internal class InspectionTemplateVersionPropertyTypesMapping : IEntityTypeConfiguration<InspectionTemplateVersionPropertyTypes>
    {
        public void Configure(EntityTypeBuilder<InspectionTemplateVersionPropertyTypes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.InspectionTemplateVersion)
                .WithMany(x => x.InspectionTemplateVersionPropertyTypes)
                .HasForeignKey(x => x.InspectionTemplateVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.PropertyType)
                .WithMany(x => x.InspectionTemplateVersionPropertyTypes)
                .HasForeignKey(x => x.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("InspectionTemplateVersionPropertyTypes", "settings");
        }
    }
}
