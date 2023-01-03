using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.AnswerMaintenance.Answers
{
    internal class AnswerVersionMapping : IEntityTypeConfiguration<AnswerVersion>
    {
        public void Configure(EntityTypeBuilder<AnswerVersion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Description))
                    .HasMaxLength(Description.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.HasOne(x => x.Answer)
                .WithMany(x => x.AnswerVersions)
                .HasForeignKey(x => x.AnswerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("AnswerVersion", "settings");
        }
    }
}
