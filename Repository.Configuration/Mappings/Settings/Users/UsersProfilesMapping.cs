using Domain.Entities.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Users
{
    public sealed class UsersProfilesMapping : IEntityTypeConfiguration<UsersProfiles>
    {
        public void Configure(EntityTypeBuilder<UsersProfiles> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UsersProfiles)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.UserProfile)
                .WithMany(x => x.UsersProfiles)
                .HasForeignKey(x => x.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("UsersProfiles", "settings");
        }
    }
}
