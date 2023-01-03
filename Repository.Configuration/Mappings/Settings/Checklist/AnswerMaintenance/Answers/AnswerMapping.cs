using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.AnswerMaintenance.Answers
{
    internal class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Version)
                .WithMany()
                .HasForeignKey(x => x.VersionId);

            builder.ToTable("Answers", "settings");

        }
    }
}
