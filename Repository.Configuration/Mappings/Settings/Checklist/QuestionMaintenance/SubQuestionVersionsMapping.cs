using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.QuestionMaintenance
{
    internal class SubQuestionVersionsMapping : IEntityTypeConfiguration<SubQuestionVersions>
    {
        public void Configure(EntityTypeBuilder<SubQuestionVersions> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.QuestionVersion)
                .WithMany(x => x.SubQuestionVersions)
                .HasForeignKey(x => x.QuestionVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.SubQuestionVersion)
                .WithMany(x => x.SubQuestionVersionsSubQuestionVersions)
                .HasForeignKey(x => x.SubQuestionVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("SubQuestionVersions", "settings");
        }
    }
}
