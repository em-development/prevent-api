using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    internal class InspectionResponsableMapping : IEntityTypeConfiguration<InspectionResponsable>
    {
        public void Configure(EntityTypeBuilder<InspectionResponsable> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Inspection)
                .WithMany(x => x.InspectionResponsables)
                .HasForeignKey(x => x.InspectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.LegalEntityContact)
                .WithMany(x => x.InspectionResponsables)
                .HasForeignKey(x => x.LegalEntityContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("InspectionResponsables", "settings");

        }
    }
}
