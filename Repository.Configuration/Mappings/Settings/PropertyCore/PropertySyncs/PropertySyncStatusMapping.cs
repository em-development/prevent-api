using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.PropertyCore.PropertySyncs
{
    internal class PropertySyncStatusMapping : IEntityTypeConfiguration<PropertySyncStatus>
    {
        public void Configure(EntityTypeBuilder<PropertySyncStatus> builder)
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
            //        Description = new { Value = "SYNCED" }
            //    },
            //    new
            //    {
            //        Id = 5,
            //        Description = new { Value = "PENDING" }
            //    },
            //    new
            //    {
            //        Id = 10,
            //        Description = new { Value = "NOT_EXIST" }
            //    }
            //);

            builder.ToTable("PropertySyncStatus", "settings");

        }
    }
}