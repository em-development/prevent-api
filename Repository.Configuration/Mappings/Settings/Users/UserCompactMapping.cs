using Domain.Compacts.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Users
{
    public sealed class UserCompactMapping : IEntityTypeConfiguration<CompactUser>
    {
        public void Configure(EntityTypeBuilder<CompactUser> builder)
        {
            builder.HasNoKey();

            builder.HasOne(x => x.Avatar)
                  .WithMany()
                  .HasForeignKey(x => x.AttachmentId);

            builder.ToView("vw_Users", "settings");
        }
    }
}
