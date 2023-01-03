using Domain.Entities.Settings.Users;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Users
{
    public sealed class UsersMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name)
                   .Property(x => x.Value)
                   .HasColumnName(nameof(Name))
                   .HasColumnType("varchar")
                   .HasMaxLength(Name.FieldMaxLength)
                   .IsRequired();

            builder.OwnsOne(x => x.Email)
                  .Property(x => x!.Value)
                  .HasColumnName(nameof(Email))
                  .HasColumnType("varchar")
                  .HasMaxLength(Email.FieldMaxLength);

            builder.OwnsOne(x => x.UId)
                  .Property(x => x!.Value)
                  .HasColumnName(nameof(UId))
                  .HasColumnType("varchar")
                  .HasMaxLength(UId.FieldMaxLength);

            builder.ToTable("Users", "settings");
        }
    }
}
