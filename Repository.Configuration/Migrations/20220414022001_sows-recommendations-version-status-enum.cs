using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowsrecommendationsversionstatusenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.RecommendationVersionStatus ON

                INSERT INTO settings.RecommendationVersionStatus(Id, Description) VALUES 
                    (1, 'PENDING'),
                    (5, 'APPROVED')

                SET IDENTITY_INSERT settings.RecommendationVersionStatus OFF
                
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.RecommendationVersionStatus");
        }
    }
}
