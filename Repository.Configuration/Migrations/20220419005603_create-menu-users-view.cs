using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class createmenuusersview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                CREATE VIEW [core].[vw_MenusUser] AS
                SELECT DISTINCT(cm.Id),
                               sup.UserId
                FROM [core].Menus cm
                         INNER JOIN [core].MenusUserProfile cmup on cm.Id = cmup.MenuId
                         INNER JOIN [settings].UsersProfiles sup on sup.UserProfileId = cmup.ProfileId
                         INNER JOIN [Settings].Users su on sup.UserId = su.Id;";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [core].[vw_MenusUser]");
        }
    }
}
