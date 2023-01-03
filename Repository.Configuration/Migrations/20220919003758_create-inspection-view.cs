using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class createinspectionview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                CREATE OR ALTER VIEW [settings].[vw_Inspections] AS
                       SELECT i.Id,
                               i.TemplateVersionId,
                               p.Name                    AS 'Description',
                               p.Address,
                               le.Name                   AS 'LegalEntity',
                               le.CodeEntity,
                               pt.Description            AS 'PropertyType',
                               ist.Id                    AS 'InspectionStatus',
                               CAST(0 AS DECIMAL(18, 2)) AS 'FillStatus',
                               us.Id                     as UserId,
                               us.Name                   as UserName
                        FROM settings.Inspections i
                                 INNER JOIN settings.Property p ON p.Id = i.PropertyId
                                 INNER JOIN settings.PropertyType pt ON pt.Id = p.PropertyTypeId
                                 INNER JOIN settings.LegalEntity le ON le.Id = p.LegalEntityId
                                 INNER JOIN settings.InspectionStatus ist ON ist.Id = i.StatusId
                                 INNER JOIN settings.Users us on i.InspectorId = us.Id";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [settings].[vw_Inspections]");
        }
    }
}
