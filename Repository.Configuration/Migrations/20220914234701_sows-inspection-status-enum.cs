using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowsinspectionstatusenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.InspectionStatus ON

                INSERT INTO settings.InspectionStatus(Id, Description) VALUES 
                    (1, 'DRAFT'),
                    (10, 'SCHEDULED'),
                    (20, 'IN_PROGRESS'),
                    (30, 'WAITING_ANALYSIS'),
                    (40, 'CONCLUDED'),
                    (50, 'CANCELED')

                SET IDENTITY_INSERT settings.InspectionStatus OFF
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.InspectionStatus");
        }
    }
}
