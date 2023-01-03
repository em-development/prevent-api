using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class recommendationsmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecommendationVersionStatus",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationVersionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommendation",
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
                    table.PrimaryKey("PK_Recommendation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationVersion",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendationId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    DueDateText = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RecommendationVersionStatusId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationVersion_Recommendation_RecommendationId",
                        column: x => x.RecommendationId,
                        principalSchema: "settings",
                        principalTable: "Recommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendationVersion_RecommendationVersionStatus_RecommendationVersionStatusId",
                        column: x => x.RecommendationVersionStatusId,
                        principalSchema: "settings",
                        principalTable: "RecommendationVersionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationVersionIssues",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendationVersionId = table.Column<int>(type: "int", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationVersionIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationVersionIssues_Issues_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "settings",
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendationVersionIssues_RecommendationVersion_RecommendationVersionId",
                        column: x => x.RecommendationVersionId,
                        principalSchema: "settings",
                        principalTable: "RecommendationVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_VersionId",
                schema: "settings",
                table: "Recommendation",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationVersion_RecommendationId",
                schema: "settings",
                table: "RecommendationVersion",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationVersion_RecommendationVersionStatusId",
                schema: "settings",
                table: "RecommendationVersion",
                column: "RecommendationVersionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationVersionIssues_IssueId",
                schema: "settings",
                table: "RecommendationVersionIssues",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationVersionIssues_RecommendationVersionId",
                schema: "settings",
                table: "RecommendationVersionIssues",
                column: "RecommendationVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendation_RecommendationVersion_VersionId",
                schema: "settings",
                table: "Recommendation",
                column: "VersionId",
                principalSchema: "settings",
                principalTable: "RecommendationVersion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendation_RecommendationVersion_VersionId",
                schema: "settings",
                table: "Recommendation");

            migrationBuilder.DropTable(
                name: "RecommendationVersionIssues",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "RecommendationVersion",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Recommendation",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "RecommendationVersionStatus",
                schema: "settings");
        }
    }
}
