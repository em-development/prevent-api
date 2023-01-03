using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.LegalEntityCore.LegalEntityContacts
{
    internal class LegalEntitySyncStatusMapping : IEntityTypeConfiguration<LegalEntitySyncStatus>
    {
        public void Configure(EntityTypeBuilder<LegalEntitySyncStatus> builder)
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

            builder.ToTable("LegalEntitySyncStatus", "settings");

        }
    }
}