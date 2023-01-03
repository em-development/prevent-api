using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowsquestiontypeenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                SET IDENTITY_INSERT settings.QuestionType ON

                INSERT INTO settings.QuestionType(Id, Description) VALUES 
                    (1,	'SINGLE_CHOICE'),
                    (5,	'MULTIPLE_CHOICE'),
                    (10, 'TEXT'),
                    (15, 'NUMBER'),
                    (20, 'MONEY'),
                    (25, 'FILE'),
                    (30, 'CHECKBOX')

                SET IDENTITY_INSERT settings.QuestionType OFF
            ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM settings.QuestionType");
        }
    }
}
