using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using Domain.ValueObjects.Settings.Checklist.QuestionsMaintenance.Questions;
using Domain.ValueObjects.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.ChecklistMaintenance
{
    internal class ChecklistVersionMapping : IEntityTypeConfiguration<ChecklistVersion>
    {
        public void Configure(EntityTypeBuilder<ChecklistVersion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Title)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Title))
                    .HasMaxLength(Title.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.OwnsOne(x => x.Key)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Key))
                    .HasMaxLength(Key.FieldMaxLength)
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.HasOne(x => x.Checklist)
                .WithMany(x => x.ChecklistVersions)
                .HasForeignKey(x => x.ChecklistId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("ChecklistVersion", "settings");
        }
    }
}
