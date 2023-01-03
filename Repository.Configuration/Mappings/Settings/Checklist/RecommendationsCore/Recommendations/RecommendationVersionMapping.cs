using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    internal class RecommendationVersionMapping : IEntityTypeConfiguration<RecommendationVersion>
    {
        public void Configure(EntityTypeBuilder<RecommendationVersion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Title)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Title))
                    .HasMaxLength(Title.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.OwnsOne(x => x.Description)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Description))
                    .HasMaxLength(Description.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.OwnsOne(x => x.DueDateText)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(DueDateText))
                    .HasMaxLength(DueDateText.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.HasOne(x => x.Recommendation)
                .WithMany(x => x.RecommendationVersions)
                .HasForeignKey(x => x.RecommendationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("RecommendationVersion", "settings");
        }
    }
}
