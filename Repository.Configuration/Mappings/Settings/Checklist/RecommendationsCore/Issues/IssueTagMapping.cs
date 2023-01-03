using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Domain.ValueObjects.Settings.Checklist.RecommendationsCore.Issues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.RecommendationsCore.Issues
{
    internal class IssueTagMapping : IEntityTypeConfiguration<IssueTag>
    {
        public void Configure(EntityTypeBuilder<IssueTag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Tag)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Tag))
                    .HasMaxLength(Tag.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.HasOne(x => x.Issue)
                  .WithMany(x => x.Tags)
                  .HasForeignKey(x => x.IssueId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .IsRequired(); ;

            builder.ToTable("IssueTags", "settings");
        }
    }
}
