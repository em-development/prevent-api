using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    internal class RecommendationVersionStatusMapping : IEntityTypeConfiguration<RecommendationVersionStatus>
    {
        public void Configure(EntityTypeBuilder<RecommendationVersionStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                .Property(x => x.Value)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(EnumDescription.FieldMaxLength)
                .IsRequired();

            //builder.HasData(
            //    new
            //    {
            //        Id = 1,
            //        Description = new { Value = "PENDING" }
            //    },
            //    new
            //    {
            //        Id = 5,
            //        Description = new { Value = "APPROVED" }
            //    }
            //);

            builder.ToTable("RecommendationVersionStatus", "settings");

        }
    }
}