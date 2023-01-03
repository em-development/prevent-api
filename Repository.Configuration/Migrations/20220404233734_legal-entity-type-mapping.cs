using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class legalentitytypemapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LegalEntityTypeId",
                schema: "settings",
                table: "LegalEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LegalEntityType",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntityType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntity_LegalEntityTypeId",
                schema: "settings",
                table: "LegalEntity",
                column: "LegalEntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalEntity_LegalEntityType_LegalEntityTypeId",
                schema: "settings",
                table: "LegalEntity",
                column: "LegalEntityTypeId",
                principalSchema: "settings",
                principalTable: "LegalEntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalEntity_LegalEntityType_LegalEntityTypeId",
                schema: "settings",
                table: "LegalEntity");

            migrationBuilder.DropTable(
                name: "LegalEntityType",
                schema: "settings");

            migrationBuilder.DropIndex(
                name: "IX_LegalEntity_LegalEntityTypeId",
                schema: "settings",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "LegalEntityTypeId",
                schema: "settings",
                table: "LegalEntity");
        }
    }
}
