using Domain.Entities.BaseLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.BaseLogs
{
    public sealed class LogoContentMapping : IEntityTypeConfiguration<LogContent>
    {
        public void Configure(EntityTypeBuilder<LogContent> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(x => x.Log)
                   .WithOne(x => x.LogContent)
                   .HasForeignKey<LogContent>(x => x.Id);

            builder.Property(x => x.Content)
                   .HasColumnType("varchar(max)")
                   .IsRequired();

            builder.ToTable("Contents", "log");
        }
    }
}
