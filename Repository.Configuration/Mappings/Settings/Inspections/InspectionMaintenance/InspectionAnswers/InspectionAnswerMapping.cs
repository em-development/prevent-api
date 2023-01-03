using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    internal class InspectionAnswerMapping : IEntityTypeConfiguration<InspectionAnswer>
    {
        public void Configure(EntityTypeBuilder<InspectionAnswer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Inspection)
                .WithMany(x => x.InspectionAnswers)
                .HasForeignKey(x => x.InspectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.ChecklistVersion)
                .WithMany(x => x.InspectionAnswers)
                .HasForeignKey(x => x.ChecklistVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.QuestionVersion)
               .WithMany(x => x.InspectionAnswers)
               .HasForeignKey(x => x.QuestionVersionId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.ToTable("InspectionAnswers", "settings");

        }
    }
}
