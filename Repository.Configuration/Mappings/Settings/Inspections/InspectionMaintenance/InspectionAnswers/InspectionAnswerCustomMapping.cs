using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.ValueObjects.Settings.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    internal class InspectionAnswerCustomMapping : IEntityTypeConfiguration<InspectionAnswerCustom>
    {
        public void Configure(EntityTypeBuilder<InspectionAnswerCustom> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.InspectionAnswer)
                .WithMany(x => x.InspectionAnswerCustoms)
                .HasForeignKey(x => x.InspectionAnswerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.OwnsOne(x => x.Answer)
                .Property(x => x.Value)
                .HasColumnName(nameof(InspectionAnswerCustomAnswer))
                .HasMaxLength(InspectionAnswerCustomAnswer.FieldMaxLength)
                .HasColumnType("varchar");

            builder.ToTable("InspectionAnswerCustom", "settings");

        }
    }
}
