using Domain.Entities.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.ValueObjects.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.Checklist.QuestionMaintenance
{
    internal class QuestionTypeMapping : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
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
            //        Description = new { Value = "SINGLE_CHOICE" }
            //    },
            //    new
            //    {
            //        Id = 5,
            //        Description = new { Value = "MULTIPLE_CHOICE" }
            //    },
            //    new
            //    {
            //        Id = 10,
            //        Description = new { Value = "TEXT" }
            //    },
            //    new
            //    {
            //        Id = 15,
            //        Description = new { Value = "NUMBER" }
            //    },
            //    new
            //    {
            //        Id = 20,
            //        Description = new { Value = "MONEY" }
            //    },
            //    new
            //    {
            //        Id = 25,
            //        Description = new { Value = "FILE" }
            //    },
            //    new
            //    {
            //        Id = 30,
            //        Description = new { Value = "CHECKBOX" }
            //    }
            //);

            builder.ToTable("QuestionType", "settings");

        }
    }
}