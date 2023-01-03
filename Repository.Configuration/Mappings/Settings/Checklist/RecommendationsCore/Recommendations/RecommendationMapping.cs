using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    internal class RecommendationMapping : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Version)
                .WithMany()
                .HasForeignKey(x => x.VersionId);

            builder.ToTable("Recommendation", "settings");

        }
    }
}
