using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Checklist.QuestionsMaintenance.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.QuestionMaintenance
{
    internal class QuestionVersionMapping : IEntityTypeConfiguration<QuestionVersion>
    {
        public void Configure(EntityTypeBuilder<QuestionVersion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Description))
                    .HasMaxLength(Description.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.OwnsOne(x => x.Tips)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Tips))
                    .HasMaxLength(Tips.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.OwnsOne(x => x.Key)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Key))
                    .HasMaxLength(Key.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.HasOne(x => x.Question)
                .WithMany(x => x.QuestionVersions)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("QuestionVersion", "settings");
        }
    }
}
