using Domain.Entities.Inspections.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Inspections.Inspections;

public class InspectionAttachmentsMapping : IEntityTypeConfiguration<InspectionAttachment>
{
    public void Configure(EntityTypeBuilder<InspectionAttachment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(d => d.Attachment)
            .WithMany()
            .HasForeignKey(d => d.AttachmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(d => d.Inspection)
            .WithMany(x => x.InspectionAttachments)
            .HasForeignKey(d => d.InspectionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasAlternateKey(x => new {x.AttachmentId, x.InspectionId});

        builder.ToTable("InspectionAttachments", "inspections");
    }
}