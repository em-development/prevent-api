using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class checklistmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checklists",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistVersion",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChecklistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Key = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistVersion_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalSchema: "settings",
                        principalTable: "Checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistVersionQuestions",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChecklistVersionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistVersionQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistVersionQuestions_ChecklistVersion_ChecklistVersionId",
                        column: x => x.ChecklistVersionId,
                        principalSchema: "settings",
                        principalTable: "ChecklistVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChecklistVersionQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "settings",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_VersionId",
                schema: "settings",
                table: "Checklists",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistVersion_ChecklistId",
                schema: "settings",
                table: "ChecklistVersion",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistVersionQuestions_ChecklistVersionId",
                schema: "settings",
                table: "ChecklistVersionQuestions",
                column: "ChecklistVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistVersionQuestions_QuestionId",
                schema: "settings",
                table: "ChecklistVersionQuestions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_ChecklistVersion_VersionId",
                schema: "settings",
                table: "Checklists",
                column: "VersionId",
                principalSchema: "settings",
                principalTable: "ChecklistVersion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_ChecklistVersion_VersionId",
                schema: "settings",
                table: "Checklists");

            migrationBuilder.DropTable(
                name: "ChecklistVersionQuestions",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "ChecklistVersion",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Checklists",
                schema: "settings");
        }
    }
}
