using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.QuestionMaintenance
{
    internal class QuestionVersionRecommendationsMapping : IEntityTypeConfiguration<QuestionVersionRecommendations>
    {
        public void Configure(EntityTypeBuilder<QuestionVersionRecommendations> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.QuestionVersion)
                .WithMany(x => x.QuestionVersionRecommendations)
                .HasForeignKey(x => x.QuestionVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.RecommendationVersion)
                .WithMany(x => x.QuestionVersionRecommendations)
                .HasForeignKey(x => x.RecommendationVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("QuestionVersionRecommendations", "settings");
        }
    }
}
