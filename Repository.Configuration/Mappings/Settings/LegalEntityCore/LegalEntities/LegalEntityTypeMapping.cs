using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.LegalEntityCore.LegalEntities
{
    internal class LegalEntitTypeMapping : IEntityTypeConfiguration<LegalEntityType>
    {
        public void Configure(EntityTypeBuilder<LegalEntityType> builder)
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
            //        Description = new { Value = "GENERAL_ASSOCIATION" }
            //    },
            //    new
            //    {
            //        Id = 5,
            //        Description = new { Value = "DIVISION" }
            //    },
            //    new
            //    {
            //        Id = 10,
            //        Description = new { Value = "UNION" }
            //    },
            //    new
            //    {
            //        Id = 15,
            //        Description = new { Value = "ASSOCIATION" }
            //    },
            //    new
            //    {
            //        Id = 20,
            //        Description = new { Value = "MISSION" }
            //    },
            //    new
            //    {
            //        Id = 25,
            //        Description = new { Value = "REGION" }
            //    },
            //    new
            //    {
            //        Id = 30,
            //        Description = new { Value = "DISTRICT" }
            //    },
            //    new
            //    {
            //        Id = 35,
            //        Description = new { Value = "COMMUNITY" }
            //    },
            //    new
            //    {
            //        Id = 40,
            //        Description = new { Value = "CLUB" }
            //    }
            //);

            builder.ToTable("LegalEntityType", "settings");

        }
    }
}