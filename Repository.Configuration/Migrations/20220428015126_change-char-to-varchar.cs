using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class changechartovarchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Source",
                schema: "log",
                table: "Logs",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                schema: "log",
                table: "Logs",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                schema: "log",
                table: "Logs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Lang",
                schema: "settings",
                table: "Countries",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "settings",
                table: "Countries",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "GuId",
                schema: "files",
                table: "Attachments",
                type: "varchar(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "files",
                table: "Attachments",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                schema: "files",
                table: "Attachments",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Bucket",
                schema: "files",
                table: "Attachments",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Source",
                schema: "log",
                table: "Logs",
                type: "char(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                schema: "log",
                table: "Logs",
                type: "char(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                schema: "log",
                table: "Logs",
                type: "char(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Lang",
                schema: "settings",
                table: "Countries",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "settings",
                table: "Countries",
                type: "char(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "GuId",
                schema: "files",
                table: "Attachments",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "files",
                table: "Attachments",
                type: "char(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                schema: "files",
                table: "Attachments",
                type: "char(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Bucket",
                schema: "files",
                table: "Attachments",
                type: "char(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }
    }
}
