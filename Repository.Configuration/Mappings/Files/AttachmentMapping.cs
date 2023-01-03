using Domain.Entities.Files;
using Domain.ValueObjects.Files;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Files
{
    internal class AttachmentMapping : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Guid)
                    .Property(v => v.Value)
                    .HasColumnName(nameof(GuId))
                    .HasColumnType("varchar")
                    .HasMaxLength(GuId.FieldLength)
                    .IsRequired();

            builder.OwnsOne(p => p.FileName)
                    .Property(v => v.Value)
                    .HasColumnName(nameof(FileName))
                    .HasColumnType("varchar")
                    .HasMaxLength(FileName.FieldMaxLength)
                    .IsRequired();

            builder.OwnsOne(p => p.ContentType)
                    .Property(v => v.Value)
                    .HasColumnName(nameof(ContentType))
                    .HasColumnType("varchar")
                    .HasMaxLength(ContentType.FieldMaxLength)
                    .IsRequired();

            builder.OwnsOne(p => p.Bucket)
                    .Property(v => v.Value)
                    .HasColumnName(nameof(Bucket))
                    .HasColumnType("varchar")
                    .HasMaxLength(Bucket.FieldMaxLength);

            builder.ToTable("Attachments", "files");
        }
    }
}
