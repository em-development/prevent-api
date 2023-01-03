using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class inspectiontemplatesmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspections",
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
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTemplateVersion",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionTemplateId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTemplateVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionTemplateVersion_Inspections_InspectionTemplateId",
                        column: x => x.InspectionTemplateId,
                        principalSchema: "settings",
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTemplateVersionChecklists",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionTemplateVersionId = table.Column<int>(type: "int", nullable: false),
                    ChecklistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTemplateVersionChecklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionTemplateVersionChecklists_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalSchema: "settings",
                        principalTable: "Checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionTemplateVersionChecklists_InspectionTemplateVersion_InspectionTemplateVersionId",
                        column: x => x.InspectionTemplateVersionId,
                        principalSchema: "settings",
                        principalTable: "InspectionTemplateVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTemplateVersionPropertyTypes",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionTemplateVersionId = table.Column<int>(type: "int", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTemplateVersionPropertyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionTemplateVersionPropertyTypes_InspectionTemplateVersion_InspectionTemplateVersionId",
                        column: x => x.InspectionTemplateVersionId,
                        principalSchema: "settings",
                        principalTable: "InspectionTemplateVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionTemplateVersionPropertyTypes_PropertyType_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalSchema: "settings",
                        principalTable: "PropertyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_VersionId",
                schema: "settings",
                table: "Inspections",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTemplateVersion_InspectionTemplateId",
                schema: "settings",
                table: "InspectionTemplateVersion",
                column: "InspectionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTemplateVersionChecklists_ChecklistId",
                schema: "settings",
                table: "InspectionTemplateVersionChecklists",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTemplateVersionChecklists_InspectionTemplateVersionId",
                schema: "settings",
                table: "InspectionTemplateVersionChecklists",
                column: "InspectionTemplateVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTemplateVersionPropertyTypes_InspectionTemplateVersionId",
                schema: "settings",
                table: "InspectionTemplateVersionPropertyTypes",
                column: "InspectionTemplateVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTemplateVersionPropertyTypes_PropertyTypeId",
                schema: "settings",
                table: "InspectionTemplateVersionPropertyTypes",
                column: "PropertyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_InspectionTemplateVersion_VersionId",
                schema: "settings",
                table: "Inspections",
                column: "VersionId",
                principalSchema: "settings",
                principalTable: "InspectionTemplateVersion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_InspectionTemplateVersion_VersionId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropTable(
                name: "InspectionTemplateVersionChecklists",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "InspectionTemplateVersionPropertyTypes",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "InspectionTemplateVersion",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Inspections",
                schema: "settings");
        }
    }
}
