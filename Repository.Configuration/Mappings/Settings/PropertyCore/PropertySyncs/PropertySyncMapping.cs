using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.ValueObjects.Settings.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.PropertyCore.PropertySyncs
{
    internal class PropertySyncMapping : IEntityTypeConfiguration<PropertySync>
    {
        public void Configure(EntityTypeBuilder<PropertySync> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.Name)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Name))
                    .HasMaxLength(Name.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.OwnsOne(x => x.Address)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Address))
                    .HasMaxLength(Address.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.OwnsOne(x => x.Code)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Code))
                    .HasMaxLength(Code.FieldMaxLength)
                    .HasColumnType("varchar");

            builder.HasOne(x => x.PropertyType)
                .WithMany(x => x.PropertySyncs)
                .HasForeignKey(x => x.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.PropertySyncs)
                .HasForeignKey(x => x.LegalEntityId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("PropertySync", "settings");

        }
    }
}