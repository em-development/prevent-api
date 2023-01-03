using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    internal class InspectionStatusMapping : IEntityTypeConfiguration<InspectionStatus>
    {
        public void Configure(EntityTypeBuilder<InspectionStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                .Property(x => x.Value)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(EnumDescription.FieldMaxLength)
                .IsRequired();

            //builder.HasData(
            //    new
            //    {
            //        Id = 1,
            //        Description = new { Value = "DRAFT" }
            //    },
            //    new
            //    {
            //        Id = 10,
            //        Description = new { Value = "SCHEDULED" }
            //    },
            //    new
            //    {
            //        Id = 20,
            //        Description = new { Value = "IN_PROGRESS" }
            //    },
            //    new
            //    {
            //        Id = 30,
            //        Description = new { Value = "WAITING_ANALYSIS" }
            //    },
            //    new
            //    {
            //        Id = 40,
            //        Description = new { Value = "CONCLUDED" }
            //    },
            //    new
            //    {
            //        Id = 50,
            //        Description = new { Value = "CANCELED" }
            //    }
            //);

            builder.ToTable("InspectionStatus", "settings");

        }
    }
}