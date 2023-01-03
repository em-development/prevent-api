using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.LegalEntityCore.LegalEntityContacts
{
    internal class LegalEntityContactMapping : IEntityTypeConfiguration<LegalEntityContact>
    {
        public void Configure(EntityTypeBuilder<LegalEntityContact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Name))
                    .HasMaxLength(Name.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.OwnsOne(x => x.Email)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Email))
                    .HasMaxLength(Email.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.HasOne(x => x.LegalEntityContactType)
                .WithMany(x => x.LegalEntityContacts)
                .HasForeignKey(x => x.LegalEntityContactTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.LegalEntityContacts)
                .HasForeignKey(x => x.LegalEntityId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("LegalEntityContact", "settings");

        }
    }
}