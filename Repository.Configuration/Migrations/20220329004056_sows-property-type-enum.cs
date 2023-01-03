using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowspropertytypeenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.PropertyType ON

                INSERT INTO settings.PropertyType(Id, Description) VALUES 
                    (1,	'Igreja Alvenaria'),
                    (2,	'Escola'),
                    (3,	'Residencia'),
                    (4,	'Escritorio'),
                    (5,	'Centro de Treinamento'),
                    (6,	'Clinica'),
                    (7,	'Hospital'),
                    (8,	'Radio'),
                    (9,	'Escola Secundária'),
                    (10, 'Universidade'),
                    (11, 'Estúdio de TV'),
                    (12, 'Estúdio de Gravação'),
                    (13, 'Depósito'),
                    (14, 'Antena de Rádio/TV'),
                    (15, 'Industria / Fabrica'),
                    (16, 'Loja'),
                    (17, 'Centro de Assistência Social'),
                    (18, 'Igreja Madeira'),
                    (19, 'Techos'),
                    (20, 'Igreja Especial'),
                    (21, 'Escritório Especial'),
                    (22, 'Espaço Novo Tempo'),
                    (23, 'Grupo em Formação'),
                    (24, 'Escola Especial')

                SET IDENTITY_INSERT settings.PropertyType ON
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.PropertyType");
        }
    }
}
