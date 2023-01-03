using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.LegalEntityCore.LegalEntities
{
    internal class LegalEntityMapping : IEntityTypeConfiguration<LegalEntity>
    {
        public void Configure(EntityTypeBuilder<LegalEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

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
                .WithMany(x => x.LegalEntities)
                .HasForeignKey(x => x.LegalEntityTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(d => d.Parent)
                    .WithMany(p => p.Childrens)
                    .HasForeignKey(d => d.ParentId);

            builder.ToTable("LegalEntity", "settings");

        }
    }
}