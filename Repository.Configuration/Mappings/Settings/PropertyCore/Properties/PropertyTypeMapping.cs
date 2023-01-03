using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Settings.PropertyCore.Properties
{
    internal class PropertyTypeMapping : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Description)
                .Property(x => x.Value)
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(EnumDescription.FieldMaxLength)
                .IsRequired();

            //builder.HasData(
            //    new { Id = 1, Description = new { Value = "Igreja Alvenaria" } },
            //    new { Id = 2, Description = new { Value = "Escola" } },
            //    new { Id = 3, Description = new { Value = "Residencia" } },
            //    new { Id = 4, Description = new { Value = "Escritorio" } },
            //    new { Id = 5, Description = new { Value = "Centro de Treinamento" } },
            //    new { Id = 6, Description = new { Value = "Clinica" } },
            //    new { Id = 7, Description = new { Value = "Hospital" } },
            //    new { Id = 8, Description = new { Value = "Radio" } },
            //    new { Id = 9, Description = new { Value = "Escola Secundária" } },
            //    new { Id = 10, Description = new { Value = "Universidade" } },
            //    new { Id = 11, Description = new { Value = "Estúdio de TV" } },
            //    new { Id = 12, Description = new { Value = "Estúdio de Gravação" } },
            //    new { Id = 13, Description = new { Value = "Depósito" } },
            //    new { Id = 14, Description = new { Value = "Antena de Rádio / TV" } },
            //    new { Id = 15, Description = new { Value = "Industria / Fabrica" } },
            //    new { Id = 16, Description = new { Value = "Loja" } },
            //    new { Id = 17, Description = new { Value = "Centro de Assistência Social" } },
            //    new { Id = 18, Description = new { Value = "Igreja Madeira" } },
            //    new { Id = 19, Description = new { Value = "Techos" } },
            //    new { Id = 20, Description = new { Value = "Igreja Especial" } },
            //    new { Id = 21, Description = new { Value = "Escritório Especial" } },
            //    new { Id = 22, Description = new { Value = "Espaço Novo Tempo" } },
            //    new { Id = 23, Description = new { Value = "Grupo em Formação" } },
            //    new { Id = 24, Description = new { Value = "Escola Especial" } }
            //);

            builder.ToTable("PropertyType", "settings");

        }
    }
}