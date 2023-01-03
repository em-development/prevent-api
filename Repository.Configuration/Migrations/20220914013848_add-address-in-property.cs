using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class addaddressinproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Users_InspectorId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "settings",
                table: "PropertySync",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "settings",
                table: "Property",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_LegalEntityContact_InspectorId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "settings",
                table: "PropertySync");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "settings",
                table: "Property");

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
    }
}
