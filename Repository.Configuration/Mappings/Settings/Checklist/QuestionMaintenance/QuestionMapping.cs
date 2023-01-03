using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.QuestionMaintenance
{
    internal class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Version)
                .WithMany()
                .HasForeignKey(x => x.VersionId);

            builder.ToTable("Questions", "settings");

        }
    }
}
