using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class answers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                schema: "settings",
                table: "IssueTags",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "settings",
                table: "Issues",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "Answers",
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
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerVersion",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerVersion_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalSchema: "settings",
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerVersionIssues",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerVersionId = table.Column<int>(type: "int", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerVersionIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerVersionIssues_AnswerVersion_AnswerVersionId",
                        column: x => x.AnswerVersionId,
                        principalSchema: "settings",
                        principalTable: "AnswerVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerVersionIssues_Issues_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "settings",
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_VersionId",
                schema: "settings",
                table: "Answers",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVersion_AnswerId",
                schema: "settings",
                table: "AnswerVersion",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVersionIssues_AnswerVersionId",
                schema: "settings",
                table: "AnswerVersionIssues",
                column: "AnswerVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVersionIssues_IssueId",
                schema: "settings",
                table: "AnswerVersionIssues",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AnswerVersion_VersionId",
                schema: "settings",
                table: "Answers",
                column: "VersionId",
                principalSchema: "settings",
                principalTable: "AnswerVersion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AnswerVersion_VersionId",
                schema: "settings",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "AnswerVersionIssues",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "AnswerVersion",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Answers",
                schema: "settings");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                schema: "settings",
                table: "IssueTags",
                type: "char(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "settings",
                table: "Issues",
                type: "char(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);
        }
    }
}
