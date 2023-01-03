using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.QuestionMaintenance
{
    internal class QuestionVersionAnswersMapping : IEntityTypeConfiguration<QuestionVersionAnswers>
    {
        public void Configure(EntityTypeBuilder<QuestionVersionAnswers> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.QuestionVersion)
                .WithMany(x => x.QuestionVersionAnswers)
                .HasForeignKey(x => x.QuestionVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.AnswerVersion)
                .WithMany(x => x.QuestionVersionAnswers)
                .HasForeignKey(x => x.AnswerVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("QuestionVersionAnswers", "settings");
        }
    }
}
