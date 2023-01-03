using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.ValueObjects.Settings.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.PropertyCore.Properties
{
    internal class PropertyMapping : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

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
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.LegalEntityId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Property", "settings");

        }
    }
}