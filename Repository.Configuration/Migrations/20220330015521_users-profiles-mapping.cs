using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class usersprofilesmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfile",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersLegalEntities",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LegalEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLegalEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersLegalEntities_LegalEntity_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalSchema: "settings",
                        principalTable: "LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersLegalEntities_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "settings",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "settings",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "settings",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersLegalEntities_LegalEntityId",
                schema: "settings",
                table: "UsersLegalEntities",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLegalEntities_UserId",
                schema: "settings",
                table: "UsersLegalEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_UserId",
                schema: "settings",
                table: "UsersProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_UserProfileId",
                schema: "settings",
                table: "UsersProfiles",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersLegalEntities",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "UsersProfiles",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "UserProfile",
                schema: "settings");
        }
    }
}
