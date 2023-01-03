using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowsuserprofileenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.UserProfile ON

                INSERT INTO settings.UserProfile(Id, Description) VALUES 
                    (1,	'SYSTEM_ADMIN'),
                    (5,	'ADMIN'),
                    (10, 'INSPECTOR'),
                    (15, 'LEGAL_ENTITY_USER')

                SET IDENTITY_INSERT settings.UserProfile OFF
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.UserProfile");
        }
    }
}
