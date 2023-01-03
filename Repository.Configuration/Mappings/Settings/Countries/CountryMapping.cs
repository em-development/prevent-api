using Domain.Entities.Settings.Countries;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Countries
{
    internal class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Description))
                    .HasMaxLength(Description.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.OwnsOne(x => x.Lang)
                  .Property(x => x.Value)
                  .HasMaxLength(5)
                  .HasColumnName("Lang")
                  .HasColumnType("varchar")
                  .IsRequired();

            builder.ToTable("Countries", "settings");
        }
    }
}
