using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowslegalentitytypeenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.LegalEntityType ON

                INSERT INTO settings.LegalEntityType(Id, Description) VALUES 
                    (1,	'DIVISAO'),
                    (2,	'UNIAO'),
                    (3, 'ASSOCIACAO'),
                    (4, 'MISSAO'),
                    (5, 'CAMPO'),
                    (6, 'HOSPITAL'),
                    (7, 'CLINICA'),
                    (8, 'INTERNATO'),
                    (9, 'IGREJA'),
                    (10, 'UNIVERSIDADE_FACULDADE'),
                    (11, 'ESCOLA'),
                    (12, 'ESCOLA_SECUNDARIA'),
                    (13, 'ACAMPAMENTO'),
                    (14, 'SELS'),
                    (15, 'CORRETORA_DE_SEGUROS'),
                    (16, 'PLANO_DE_SAUDE'),
                    (17, 'PREVIDENCIA_ASSISTENCIAL'),
                    (18, 'INSTITUIÇÃO'),
                    (19, 'RADIO'),
                    (20, 'TELEVISÃO'),
                    (21, 'ADRA'),
                    (22, 'CASA_PUBLICADORA'),
                    (23, 'FABRICA_INDUSTRIA')

                SET IDENTITY_INSERT settings.LegalEntityType OFF
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.LegalEntityType");
        }
    }
}
