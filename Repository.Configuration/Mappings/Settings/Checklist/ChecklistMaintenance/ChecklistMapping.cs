using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.ChecklistMaintenance
{
    internal class ChecklistMapping : IEntityTypeConfiguration<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Version)
                .WithMany()
                .HasForeignKey(x => x.VersionId);

            builder.ToTable("Checklists", "settings");

        }
    }
}
