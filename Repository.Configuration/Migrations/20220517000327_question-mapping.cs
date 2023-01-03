using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class questionmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionType",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
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
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionVersion",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Tips = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Key = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    EnableNotApply = table.Column<bool>(type: "bit", nullable: false),
                    RequireSelfInspection = table.Column<bool>(type: "bit", nullable: false),
                    RequireValidation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionVersion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "settings",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionVersion_QuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalSchema: "settings",
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionVersionAnswers",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionVersionId = table.Column<int>(type: "int", nullable: false),
                    AnswerVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionVersionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionVersionAnswers_AnswerVersion_AnswerVersionId",
                        column: x => x.AnswerVersionId,
                        principalSchema: "settings",
                        principalTable: "AnswerVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionVersionAnswers_QuestionVersion_QuestionVersionId",
                        column: x => x.QuestionVersionId,
                        principalSchema: "settings",
                        principalTable: "QuestionVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionVersionRecommendations",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionVersionId = table.Column<int>(type: "int", nullable: false),
                    RecommendationVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionVersionRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionVersionRecommendations_QuestionVersion_QuestionVersionId",
                        column: x => x.QuestionVersionId,
                        principalSchema: "settings",
                        principalTable: "QuestionVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionVersionRecommendations_RecommendationVersion_RecommendationVersionId",
                        column: x => x.RecommendationVersionId,
                        principalSchema: "settings",
                        principalTable: "RecommendationVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubQuestionVersions",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionVersionId = table.Column<int>(type: "int", nullable: false),
                    SubQuestionVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubQuestionVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubQuestionVersions_QuestionVersion_QuestionVersionId",
                        column: x => x.QuestionVersionId,
                        principalSchema: "settings",
                        principalTable: "QuestionVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubQuestionVersions_QuestionVersion_SubQuestionVersionId",
                        column: x => x.SubQuestionVersionId,
                        principalSchema: "settings",
                        principalTable: "QuestionVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_VersionId",
                schema: "settings",
                table: "Questions",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVersion_QuestionId",
                schema: "settings",
                table: "QuestionVersion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVersion_QuestionTypeId",
                schema: "settings",
                table: "QuestionVersion",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVersionAnswers_AnswerVersionId",
                schema: "settings",
                table: "QuestionVersionAnswers",
                column: "AnswerVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVersionAnswers_QuestionVersionId",
                schema: "settings",
                table: "QuestionVersionAnswers",
                column: "QuestionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVersionRecommendations_QuestionVersionId",
                schema: "settings",
                table: "QuestionVersionRecommendations",
                column: "QuestionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVersionRecommendations_RecommendationVersionId",
                schema: "settings",
                table: "QuestionVersionRecommendations",
                column: "RecommendationVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubQuestionVersions_QuestionVersionId",
                schema: "settings",
                table: "SubQuestionVersions",
                column: "QuestionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubQuestionVersions_SubQuestionVersionId",
                schema: "settings",
                table: "SubQuestionVersions",
                column: "SubQuestionVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionVersion_VersionId",
                schema: "settings",
                table: "Questions",
                column: "VersionId",
                principalSchema: "settings",
                principalTable: "QuestionVersion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionVersion_VersionId",
                schema: "settings",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionVersionAnswers",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "QuestionVersionRecommendations",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "SubQuestionVersions",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "QuestionVersion",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "QuestionType",
                schema: "settings");
        }
    }
}
