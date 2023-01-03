using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class inspections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_InspectionTemplateVersion_VersionId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionTemplateVersion_Inspections_InspectionTemplateId",
                schema: "settings",
                table: "InspectionTemplateVersion");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_VersionId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "VersionId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "settings",
                table: "Inspections",
                newName: "IsHighRisk");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "settings",
            //    table: "PropertySync",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "settings",
            //    table: "LegalEntitySync",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CoverageBegin",
                schema: "settings",
                table: "Inspections",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverageEnd",
                schema: "settings",
                table: "Inspections",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CoveragePremium",
                schema: "settings",
                table: "Inspections",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "InspectorId",
                schema: "settings",
                table: "Inspections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                schema: "settings",
                table: "Inspections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "settings",
                table: "Inspections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemplateVersionId",
                schema: "settings",
                table: "Inspections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InspectionAnswers",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    ChecklistVersionId = table.Column<int>(type: "int", nullable: false),
                    QuestionVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionAnswers_ChecklistVersion_ChecklistVersionId",
                        column: x => x.ChecklistVersionId,
                        principalSchema: "settings",
                        principalTable: "ChecklistVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionAnswers_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalSchema: "settings",
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionAnswers_QuestionVersion_QuestionVersionId",
                        column: x => x.QuestionVersionId,
                        principalSchema: "settings",
                        principalTable: "QuestionVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionPropertyBuildings",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    Measures = table.Column<int>(type: "int", nullable: false),
                    InspectionPropertyBuildingDescription = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    BuildingPattern = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    BuildingPatternRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionPropertyBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionPropertyBuildings_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalSchema: "settings",
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionPropertyCoverages",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    Coverage = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionPropertyCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionPropertyCoverages_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalSchema: "settings",
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionStatus",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTemplates",
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
                    table.PrimaryKey("PK_InspectionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionTemplates_InspectionTemplateVersion_VersionId",
                        column: x => x.VersionId,
                        principalSchema: "settings",
                        principalTable: "InspectionTemplateVersion",
                        principalColumn: "Id");
                });

            //migrationBuilder.CreateTable(
            //    name: "Menus",
            //    schema: "core",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ParentId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Menus", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Menus_Menus_ParentId",
            //            column: x => x.ParentId,
            //            principalSchema: "core",
            //            principalTable: "Menus",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "InspectionAnswerCustom",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionAnswerId = table.Column<int>(type: "int", nullable: false),
                    InspectionAnswerCustomAnswer = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionAnswerCustom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionAnswerCustom_InspectionAnswers_InspectionAnswerId",
                        column: x => x.InspectionAnswerId,
                        principalSchema: "settings",
                        principalTable: "InspectionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionAnswerVersions",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionAnswerId = table.Column<int>(type: "int", nullable: false),
                    AnswerVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionAnswerVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionAnswerVersions_AnswerVersion_AnswerVersionId",
                        column: x => x.AnswerVersionId,
                        principalSchema: "settings",
                        principalTable: "AnswerVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionAnswerVersions_InspectionAnswers_InspectionAnswerId",
                        column: x => x.InspectionAnswerId,
                        principalSchema: "settings",
                        principalTable: "InspectionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateTable(
            //    name: "MenusUserProfile",
            //    schema: "core",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MenuId = table.Column<int>(type: "int", nullable: false),
            //        ProfileId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MenusUserProfile", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_MenusUserProfile_Menus_MenuId",
            //            column: x => x.MenuId,
            //            principalSchema: "core",
            //            principalTable: "Menus",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_MenusUserProfile_UserProfile_ProfileId",
            //            column: x => x.ProfileId,
            //            principalSchema: "settings",
            //            principalTable: "UserProfile",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_InspectorId",
                schema: "settings",
                table: "Inspections",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_PropertyId",
                schema: "settings",
                table: "Inspections",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_StatusId",
                schema: "settings",
                table: "Inspections",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_TemplateVersionId",
                schema: "settings",
                table: "Inspections",
                column: "TemplateVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAnswerCustom_InspectionAnswerId",
                schema: "settings",
                table: "InspectionAnswerCustom",
                column: "InspectionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAnswers_ChecklistVersionId",
                schema: "settings",
                table: "InspectionAnswers",
                column: "ChecklistVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAnswers_InspectionId",
                schema: "settings",
                table: "InspectionAnswers",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAnswers_QuestionVersionId",
                schema: "settings",
                table: "InspectionAnswers",
                column: "QuestionVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAnswerVersions_AnswerVersionId",
                schema: "settings",
                table: "InspectionAnswerVersions",
                column: "AnswerVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAnswerVersions_InspectionAnswerId",
                schema: "settings",
                table: "InspectionAnswerVersions",
                column: "InspectionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPropertyBuildings_InspectionId",
                schema: "settings",
                table: "InspectionPropertyBuildings",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPropertyCoverages_InspectionId",
                schema: "settings",
                table: "InspectionPropertyCoverages",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTemplates_VersionId",
                schema: "settings",
                table: "InspectionTemplates",
                column: "VersionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Menus_ParentId",
            //    schema: "core",
            //    table: "Menus",
            //    column: "ParentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MenusUserProfile_MenuId",
            //    schema: "core",
            //    table: "MenusUserProfile",
            //    column: "MenuId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MenusUserProfile_ProfileId",
            //    schema: "core",
            //    table: "MenusUserProfile",
            //    column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_InspectionStatus_StatusId",
                schema: "settings",
                table: "Inspections",
                column: "StatusId",
                principalSchema: "settings",
                principalTable: "InspectionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_InspectionTemplateVersion_TemplateVersionId",
                schema: "settings",
                table: "Inspections",
                column: "TemplateVersionId",
                principalSchema: "settings",
                principalTable: "InspectionTemplateVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Property_PropertyId",
                schema: "settings",
                table: "Inspections",
                column: "PropertyId",
                principalSchema: "settings",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Users_InspectorId",
                schema: "settings",
                table: "Inspections",
                column: "InspectorId",
                principalSchema: "settings",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionTemplateVersion_InspectionTemplates_InspectionTemplateId",
                schema: "settings",
                table: "InspectionTemplateVersion",
                column: "InspectionTemplateId",
                principalSchema: "settings",
                principalTable: "InspectionTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_InspectionStatus_StatusId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_InspectionTemplateVersion_TemplateVersionId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Property_PropertyId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Users_InspectorId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionTemplateVersion_InspectionTemplates_InspectionTemplateId",
                schema: "settings",
                table: "InspectionTemplateVersion");

            migrationBuilder.DropTable(
                name: "InspectionAnswerCustom",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "InspectionAnswerVersions",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "InspectionPropertyBuildings",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "InspectionPropertyCoverages",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "InspectionStatus",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "InspectionTemplates",
                schema: "settings");

            //migrationBuilder.DropTable(
            //    name: "MenusUserProfile",
            //    schema: "core");

            migrationBuilder.DropTable(
                name: "InspectionAnswers",
                schema: "settings");

            //migrationBuilder.DropTable(
            //    name: "Menus",
            //    schema: "core");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_InspectorId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_PropertyId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_StatusId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_TemplateVersionId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "CoverageBegin",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "CoverageEnd",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "CoveragePremium",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "InspectorId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "TemplateVersionId",
                schema: "settings",
                table: "Inspections");

            migrationBuilder.RenameColumn(
                name: "IsHighRisk",
                schema: "settings",
                table: "Inspections",
                newName: "IsActive");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "settings",
            //    table: "PropertySync",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "settings",
            //    table: "LegalEntitySync",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                schema: "settings",
                table: "Inspections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_VersionId",
                schema: "settings",
                table: "Inspections",
                column: "VersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_InspectionTemplateVersion_VersionId",
                schema: "settings",
                table: "Inspections",
                column: "VersionId",
                principalSchema: "settings",
                principalTable: "InspectionTemplateVersion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionTemplateVersion_Inspections_InspectionTemplateId",
                schema: "settings",
                table: "InspectionTemplateVersion",
                column: "InspectionTemplateId",
                principalSchema: "settings",
                principalTable: "Inspections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
