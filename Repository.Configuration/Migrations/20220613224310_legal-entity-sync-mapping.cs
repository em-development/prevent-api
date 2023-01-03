using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class legalentitysyncmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalEntitySyncStatus",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntitySyncStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalEntitySync",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CodeEntity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    LegalEntityTypeId = table.Column<int>(type: "int", nullable: false),
                    LegalEntitySyncStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntitySync", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntitySync_LegalEntitySync_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "settings",
                        principalTable: "LegalEntitySync",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalEntitySync_LegalEntitySyncStatus_LegalEntitySyncStatusId",
                        column: x => x.LegalEntitySyncStatusId,
                        principalSchema: "settings",
                        principalTable: "LegalEntitySyncStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalEntitySync_LegalEntityType_LegalEntityTypeId",
                        column: x => x.LegalEntityTypeId,
                        principalSchema: "settings",
                        principalTable: "LegalEntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntitySync_LegalEntitySyncStatusId",
                schema: "settings",
                table: "LegalEntitySync",
                column: "LegalEntitySyncStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntitySync_LegalEntityTypeId",
                schema: "settings",
                table: "LegalEntitySync",
                column: "LegalEntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntitySync_ParentId",
                schema: "settings",
                table: "LegalEntitySync",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalEntitySync",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "LegalEntitySyncStatus",
                schema: "settings");
        }
    }
}
