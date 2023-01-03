using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowspropertysyncstatusenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.PropertySyncStatus ON

                INSERT INTO settings.PropertySyncStatus(Id, Description) VALUES 
                    (1, 'SYNCED'),
                    (5, 'PENDING'),
                    (10, 'NOT_EXIST')

                SET IDENTITY_INSERT settings.PropertySyncStatus OFF
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.PropertySyncStatus");
        }
    }
}
