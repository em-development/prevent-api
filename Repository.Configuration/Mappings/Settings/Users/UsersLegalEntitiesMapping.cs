using Domain.Entities.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Users
{
    public sealed class UsersLegalEntitiesMapping : IEntityTypeConfiguration<UsersLegalEntities>
    {
        public void Configure(EntityTypeBuilder<UsersLegalEntities> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UsersLegalEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.UsersLegalEntities)
                .HasForeignKey(x => x.LegalEntityId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("UsersLegalEntities", "settings");
        }
    }
}
