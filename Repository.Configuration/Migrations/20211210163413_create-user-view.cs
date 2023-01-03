using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class createuserview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                 CREATE OR ALTER VIEW [settings].[vw_Users] AS
                    SELECT u.Id,
                        u.Name,
                        u.Email,
                        u.UId,
                        null as AttachmentId
                    FROM Settings.Users u;";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [settings].[vw_Users]");
        }
    }
}
