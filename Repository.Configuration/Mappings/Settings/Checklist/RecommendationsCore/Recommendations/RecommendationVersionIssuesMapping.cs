using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    internal class RecommendationVersionIssuesMapping : IEntityTypeConfiguration<RecommendationVersionIssue>
    {
        public void Configure(EntityTypeBuilder<RecommendationVersionIssue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.RecommendationVersion)
                .WithMany(x => x.RecommendationVersionIssues)
                .HasForeignKey(x => x.RecommendationVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Issue)
                .WithMany(x => x.RecommendationVersionIssues)
                .HasForeignKey(x => x.IssueId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("RecommendationVersionIssues", "settings");
        }
    }
}
