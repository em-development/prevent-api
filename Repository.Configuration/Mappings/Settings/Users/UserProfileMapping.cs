using Domain.Entities.Settings.Users;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.LegalEntityCore.LegalEntityContacts
{
    internal class UserProfileMapping : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
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
            //        Description = new { Value = "ADMIN" }
            //    },
            //    new
            //    {
            //        Id = 5,
            //        Description = new { Value = "LEGAL_ENTITY_USER" }
            //    },
            //    new
            //    {
            //        Id = 10,
            //        Description = new { Value = "INSPECTOR" }
            //    }
            //);

            builder.ToTable("UserProfile", "settings");

        }
    }
}