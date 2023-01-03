using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    internal class InspectionAnswerVersionMapping : IEntityTypeConfiguration<InspectionAnswerVersion>
    {
        public void Configure(EntityTypeBuilder<InspectionAnswerVersion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.InspectionAnswer)
                .WithMany(x => x.InspectionAnswerVersions)
                .HasForeignKey(x => x.InspectionAnswerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.AnswerVersion)
                .WithMany(x => x.InspectionAnswerVersions)
                .HasForeignKey(x => x.AnswerVersionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("InspectionAnswerVersions", "settings");

        }
    }
}
