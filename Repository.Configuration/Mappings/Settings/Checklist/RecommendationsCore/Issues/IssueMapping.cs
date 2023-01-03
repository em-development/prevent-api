using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.RecommendationsCore.Issues
{
    internal class IssueMapping : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Description))
                    .HasMaxLength(Description.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.ToTable("Issues", "settings");
        }
    }
}
