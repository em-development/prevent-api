using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    internal class InspectionScheduleMapping : IEntityTypeConfiguration<InspectionSchedule>
    {
        public void Configure(EntityTypeBuilder<InspectionSchedule> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(x => x.Inspection)
                   .WithOne(x => x.InspectionSchedule)
                   .HasForeignKey<InspectionSchedule>(x => x.Id);

            builder.ToTable("InspectionSchedules", "settings");

        }
    }
}
