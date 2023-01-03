using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.LegalEntityCore.LegalEntitySyncs
{
    internal class LegalEntitySyncMapping : IEntityTypeConfiguration<LegalEntitySync>
    {
        public void Configure(EntityTypeBuilder<LegalEntitySync> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.Name)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(Name))
                    .HasMaxLength(Name.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.OwnsOne(x => x.CodeEntity)
                    .Property(x => x.Value)
                    .HasColumnName(nameof(CodeEntity))
                    .HasMaxLength(CodeEntity.FieldMaxLength)
                    .HasColumnType("varchar")
                    .IsRequired();

            builder.HasOne(x => x.LegalEntityType)
                .WithMany(x => x.LegalEntitySyncs)
                .HasForeignKey(x => x.LegalEntityTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(d => d.Parent)
                    .WithMany(p => p.Childrens)
                    .HasForeignKey(d => d.ParentId);

            builder.ToTable("LegalEntitySync", "settings");

        }
    }
}