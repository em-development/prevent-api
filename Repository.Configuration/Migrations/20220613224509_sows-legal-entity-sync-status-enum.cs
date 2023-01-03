using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowslegalentitysyncstatusenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.LegalEntitySyncStatus ON

                INSERT INTO settings.LegalEntitySyncStatus(Id, Description) VALUES 
                    (1, 'SYNCED'),
                    (5, 'PENDING'),
                    (10, 'NOT_EXIST')

                SET IDENTITY_INSERT settings.LegalEntitySyncStatus OFF
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.LegalEntitySyncStatus");
        }
    }
}
