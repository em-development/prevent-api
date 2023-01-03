using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.AnswerMaintenance.Answers
{
    internal class AnswerVersionIssuesMapping : IEntityTypeConfiguration<AnswerVersionIssues>
    {
        public void Configure(EntityTypeBuilder<AnswerVersionIssues> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AnswerVersion)
                .WithMany(x => x.AnswerVersionIssues)
                .HasForeignKey(x => x.AnswerVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Issue)
                .WithMany(x => x.AnswerVersionIssues)
                .HasForeignKey(x => x.IssueId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("AnswerVersionIssues", "settings");
        }
    }
}
