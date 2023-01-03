using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.LegalEntityCore.LegalEntityContacts
{
    internal class LegalEntityContactTypeMapping : IEntityTypeConfiguration<LegalEntityContactType>
    {
        public void Configure(EntityTypeBuilder<LegalEntityContactType> builder)
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
            //        Description = new { Value = "TREASURER" }
            //    },
            //    new
            //    {
            //        Id = 5,
            //        Description = new { Value = "PRESIDENT" }
            //    },
            //    new
            //    {
            //        Id = 10,
            //        Description = new { Value = "SECRETARY" }
            //    }
            //);

            builder.ToTable("LegalEntityContactType", "settings");

        }
    }
}