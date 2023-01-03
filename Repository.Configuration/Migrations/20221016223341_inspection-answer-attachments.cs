using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class inspectionanswerattachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inspections");

            migrationBuilder.CreateTable(
                name: "InspectionAttachments",
                schema: "inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionAttachments", x => x.Id);
                    table.UniqueConstraint("AK_InspectionAttachments_AttachmentId_InspectionId", x => new { x.AttachmentId, x.InspectionId });
                    table.ForeignKey(
                        name: "FK_InspectionAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalSchema: "files",
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionAttachments_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalSchema: "settings",
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionAnswerAttachments",
                schema: "inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionAttachmentId = table.Column<int>(type: "int", nullable: false),
                    InspectionAnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionAnswerAttachments", x => x.Id);
                    table.UniqueConstraint("AK_InspectionAnswerAttachments_InspectionAttachmentId_InspectionAnswerId", x => new { x.InspectionAttachmentId, x.InspectionAnswerId });
                    table.ForeignKey(
                        name: "FK_InspectionAnswerAttachments_InspectionAnswers_InspectionAnswerId",
                        column: x => x.InspectionAnswerId,
                        principalSchema: "settings",
                        principalTable: "InspectionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionAnswerAttachments_InspectionAttachments_InspectionAttachmentId",
                        column: x => x.InspectionAttachmentId,
                        principalSchema: "inspections",
                        principalTable: "InspectionAttachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAnswerAttachments_InspectionAnswerId",
                schema: "inspections",
                table: "InspectionAnswerAttachments",
                column: "InspectionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAttachments_InspectionId",
                schema: "inspections",
                table: "InspectionAttachments",
                column: "InspectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionAnswerAttachments",
                schema: "inspections");

            migrationBuilder.DropTable(
                name: "InspectionAttachments",
                schema: "inspections");
        }
    }
}
