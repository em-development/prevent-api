using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    internal class InspectionTemplateVersionChecklistsMapping : IEntityTypeConfiguration<InspectionTemplateVersionChecklists>
    {
        public void Configure(EntityTypeBuilder<InspectionTemplateVersionChecklists> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.InspectionTemplateVersion)
                .WithMany(x => x.InspectionTemplateVersionChecklists)
                .HasForeignKey(x => x.InspectionTemplateVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Checklist)
                .WithMany(x => x.InspectionTemplateVersionChecklists)
                .HasForeignKey(x => x.ChecklistId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("InspectionTemplateVersionChecklists", "settings");
        }
    }
}
