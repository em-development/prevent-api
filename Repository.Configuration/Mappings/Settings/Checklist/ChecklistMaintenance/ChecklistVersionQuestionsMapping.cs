using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.ChecklistMaintenance
{
    internal class ChecklistVersionQuestionsMapping : IEntityTypeConfiguration<ChecklistVersionQuestions>
    {
        public void Configure(EntityTypeBuilder<ChecklistVersionQuestions> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ChecklistVersion)
                .WithMany(x => x.ChecklistVersionQuestions)
                .HasForeignKey(x => x.ChecklistVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Question)
                .WithMany(x => x.ChecklistVersionQuestions)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("ChecklistVersionQuestions", "settings");
        }
    }
}
