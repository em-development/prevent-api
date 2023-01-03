using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class inspectionresponsables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Measures",
                schema: "settings",
                table: "InspectionPropertyBuildings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "InspectionResponsables",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    LegalEntityContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionResponsables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionResponsables_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalSchema: "settings",
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionResponsables_LegalEntityContact_LegalEntityContactId",
                        column: x => x.LegalEntityContactId,
                        principalSchema: "settings",
                        principalTable: "LegalEntityContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionResponsables_InspectionId",
                schema: "settings",
                table: "InspectionResponsables",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionResponsables_LegalEntityContactId",
                schema: "settings",
                table: "InspectionResponsables",
                column: "LegalEntityContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionResponsables",
                schema: "settings");

            migrationBuilder.AlterColumn<int>(
                name: "Measures",
                schema: "settings",
                table: "InspectionPropertyBuildings",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
