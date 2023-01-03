using Domain.Entities.Inspections.InspectionAnswers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Inspections.InspectionAnswers;

public class InspectionAnswerAttachmentMapping : IEntityTypeConfiguration<InspectionAnswerAttachment>
{
    public void Configure(EntityTypeBuilder<InspectionAnswerAttachment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(d => d.InspectionAttachment)
            .WithMany()
            .HasForeignKey(d => d.InspectionAttachmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(d => d.InspectionAnswer)
            .WithMany(x => x.InspectionAnswerAttachments)
            .HasForeignKey(d => d.InspectionAnswerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        
        builder.HasAlternateKey(x => new{x.InspectionAttachmentId, x.InspectionAnswerId});

        builder.ToTable("InspectionAnswerAttachments", "inspections");
    }
}