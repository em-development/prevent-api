using Domain.Entities.BaseLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.BaseLogs
{
    public sealed class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Source)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Reference)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);

            builder.Property(x => x.Action)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.ToTable("Logs", "log");
        }
    }
}
