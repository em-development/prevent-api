using Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Core
{
    public class MenuUserProfileMapping : IEntityTypeConfiguration<MenuUserProfile>
    {
        public void Configure(EntityTypeBuilder<MenuUserProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Menu)
                .WithMany(x => x.MenuUserProfiles)
                .HasForeignKey(x => x.MenuId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.MenuUserProfiles)
                .HasForeignKey(x => x.ProfileId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("MenusUserProfile", "core");
        }
    }
}