using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowslegalentitycontacttypeenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.LegalEntityContactType ON

                INSERT INTO settings.LegalEntityContactType(Id, Description) VALUES 
                    (1, 'TREASURER'),
                    (5, 'PRESIDENT'),
                    (10, 'SECRETARY'),
                    (15, 'INSPECTION_RESPONSABLE')

                SET IDENTITY_INSERT settings.LegalEntityContactType OFF
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.LegalEntityContactType");
        }
    }
}
