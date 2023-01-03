using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class recommendationattachmentmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecommendationAttachment",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendationVersionId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationAttachment_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalSchema: "files",
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendationAttachment_RecommendationVersion_RecommendationVersionId",
                        column: x => x.RecommendationVersionId,
                        principalSchema: "settings",
                        principalTable: "RecommendationVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationAttachment_AttachmentId",
                schema: "settings",
                table: "RecommendationAttachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationAttachment_RecommendationVersionId",
                schema: "settings",
                table: "RecommendationAttachment",
                column: "RecommendationVersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecommendationAttachment",
                schema: "settings");
        }
    }
}
