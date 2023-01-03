using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class inspectionschedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_LegalEntityContact_InspectorId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.CreateTable(
                name: "InspectionSchedules",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionSchedules_Inspections_Id",
                        column: x => x.Id,
                        principalSchema: "settings",
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Users_InspectorId",
                schema: "settings",
                table: "Inspections",
                column: "InspectorId",
                principalSchema: "settings",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Users_InspectorId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropTable(
                name: "InspectionSchedules",
                schema: "settings");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_LegalEntityContact_InspectorId",
                schema: "settings",
                table: "Inspections",
                column: "InspectorId",
                principalSchema: "settings",
                principalTable: "LegalEntityContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
