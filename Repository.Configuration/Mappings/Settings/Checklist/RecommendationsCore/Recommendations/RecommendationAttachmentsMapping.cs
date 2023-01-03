using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    internal class RecommendationAttachmentMapping : IEntityTypeConfiguration<RecommendationAttachment>
    {
        public void Configure(EntityTypeBuilder<RecommendationAttachment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(d => d.Attachment)
                .WithMany()
                .HasForeignKey(d => d.AttachmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(d => d.RecommendationVersion)
                .WithMany(x => x.RecommendationAttachments)
                .HasForeignKey(d => d.RecommendationVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("RecommendationAttachment", "settings");
        }
    }
}
