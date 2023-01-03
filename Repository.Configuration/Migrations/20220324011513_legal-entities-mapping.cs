using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class legalentitiesmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalEntity",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CodeEntity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntity_LegalEntity_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "settings",
                        principalTable: "LegalEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegalEntityContactType",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntityContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalEntityContact",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalEntityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    LegalEntityContactTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntityContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntityContact_LegalEntity_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalSchema: "settings",
                        principalTable: "LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalEntityContact_LegalEntityContactType_LegalEntityContactTypeId",
                        column: x => x.LegalEntityContactTypeId,
                        principalSchema: "settings",
                        principalTable: "LegalEntityContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntity_ParentId",
                schema: "settings",
                table: "LegalEntity",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntityContact_LegalEntityContactTypeId",
                schema: "settings",
                table: "LegalEntityContact",
                column: "LegalEntityContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntityContact_LegalEntityId",
                schema: "settings",
                table: "LegalEntityContact",
                column: "LegalEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalEntityContact",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "LegalEntity",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "LegalEntityContactType",
                schema: "settings");
        }
    }
}
