using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class propertysyncmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertySyncStatus",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySyncStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertySync",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LegalEntityId = table.Column<int>(type: "int", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    PropertySyncStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySync", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertySync_LegalEntity_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalSchema: "settings",
                        principalTable: "LegalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertySync_PropertySyncStatus_PropertySyncStatusId",
                        column: x => x.PropertySyncStatusId,
                        principalSchema: "settings",
                        principalTable: "PropertySyncStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertySync_PropertyType_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalSchema: "settings",
                        principalTable: "PropertyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertySync_LegalEntityId",
                schema: "settings",
                table: "PropertySync",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySync_PropertySyncStatusId",
                schema: "settings",
                table: "PropertySync",
                column: "PropertySyncStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySync_PropertyTypeId",
                schema: "settings",
                table: "PropertySync",
                column: "PropertyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertySync",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "PropertySyncStatus",
                schema: "settings");
        }
    }
}
