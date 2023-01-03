using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Configuration.Migrations
{
    public partial class sowsmenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-dashboard', null, 'basic', 'heroicons_outline:chart-pie', '/dashboard', null);
                declare @dashboard int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@dashboard, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-examples', null, 'collapsable', 'heroicons_outline:code', null, null);
                DECLARE @examples int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@examples, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-blank-page', null, 'basic', 'heroicons_outline:document', '/examples/empty', @Examples);
                DECLARE @empty_page int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@empty_page, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-crud-on-line', null, 'basic', 'mat_outline:domain_verification', '/examples/inline-crud', @Examples);
                DECLARE @row_crud int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@row_crud, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-side-crud', null, 'basic', 'mat_outline:burst_mode', '/examples/side-crud/', @Examples);
                DECLARE @side_crud int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@side_crud, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-crud-in-form', null, 'basic', 'mat_outline:domain_verification', '/examples/form-crud/', @Examples);
                DECLARE @form_crud int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@form_crud, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-general-Settings', 'ui-menu-general-Settings-subtitle', 'group', 'heroicons_outline:pencil-alt', null,
                        null);
                DECLARE @local_settings int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@local_settings, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-users', null, 'collapsable', 'heroicons_outline:users', null, @local_settings);
                DECLARE @settings_user int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_user, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-profiles', null, 'basic', 'heroicons_outline:user-group', '/settings/general/profiles', @settings_user);
                declare @profiles int = SCOPE_IDENTITY();
                    
                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@profiles, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-users', null, 'basic', 'heroicons_outline:users', '/settings/general/users', @settings_user);
                DECLARE @settings_users_user int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_users_user, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-entities', null, 'collapsable', 'heroicons_outline:office-building', null, @local_settings);
                DECLARE @settings_entity int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_entity, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-sync-entities', null, 'basic', 'heroicons_outline:refresh', '/settings/general/entity-sync',
                        @settings_entity);
                DECLARE @settings_entity_sync int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_entity_sync, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-entities', null, 'basic', 'heroicons_outline:office-building', '/settings/general/entity', @settings_entity);
                DECLARE @settings_entity_entity int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_entity_entity, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-properties', null, 'collapsable', 'heroicons_outline:home', null, @local_settings);
                DECLARE @settings_property int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_property, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-sync-properties', null, 'basic', 'heroicons_outline:refresh', '/settings/general/property-sync',
                        @settings_property);
                DECLARE @settings_property_sync int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_property_sync, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-properties', null, 'basic', 'heroicons_outline:home', '/settings/general/property', @settings_property);
                DECLARE @settings_property_property int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@settings_property_property, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-checkList-settings', 'ui-menu-checkList-settings-subtitle', 'group', 'heroicons_outline:pencil-alt', null, null);
                DECLARE @checklist int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-recommendations', null, 'collapsable', 'heroicons_outline:code', null, @checklist);
                DECLARE @checklist_recommendations int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_recommendations, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-checklists', null, 'basic', 'heroicons_outline:clipboard-check', '/settings/checklist/checklist-maintenance', @checklist);
                DECLARE @checklist_checklist int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_checklist, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-issues', null, 'basic', 'heroicons_outline:document', '/settings/checklist/recommendations/issues', @checklist_recommendations);
                DECLARE @checklist_recommendations_issues int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_recommendations_issues, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-recommendations', null, 'basic', 'heroicons_outline:code', '/settings/checklist/recommendations/recommendations', @checklist_recommendations);
                DECLARE @checklist_recommendations_recommendations int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_recommendations_recommendations, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-questions', null, 'collapsable', 'heroicons_outline:question-mark-circle', null, @checklist);
                DECLARE @checklist_question int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_question, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-answers', null, 'basic', 'heroicons_outline:chat-alt-2', '/settings/checklist/questions/answer-maintenance', @checklist_question);
                DECLARE @checklist_answer int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_answer, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-questions', null, 'basic', 'heroicons_outline:question-mark-circle', '/settings/checklist/questions/question-maintenance', @checklist_question);
                DECLARE @checklist_question_question int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_question_question, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-inspection-template', null, 'basic', 'heroicons_outline:clipboard-list', '/settings/inspections/inspection-template-maintenance', @checklist);
                DECLARE @checklist_template int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@checklist_template, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-inspections-group', 'ui-menu-inspections-group-subtitle', 'group', null, null, null);
                DECLARE @inspections_group int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@inspections_group, 1);

                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-inspections-maintenance', null, 'basic', 'heroicons_solid:clipboard-copy', '/inspections/inspections-maintenance', @inspections_group);
                DECLARE @inspections int = SCOPE_IDENTITY();
                
                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-inspections', null, 'basic', 'heroicons_solid:clipboard-check', '/inspections/answer', @inspections_group);
                DECLARE @inspections_answer int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@inspections_answer, 1);
                
                INSERT INTO [core].[menus] (Title, Subtitle, Type, Icon, Link, ParentId)
                VALUES ('ui-menu-inspections-analysis', null, 'basic', 'note_alt', '/inspections/analysis', @inspections_group);
                DECLARE @inspections_analysis int = SCOPE_IDENTITY();

                INSERT INTO [core].[MenusUserProfile] (MenuId, ProfileId)
                VALUES (@inspections_analysis, 1);

                ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                TRUNCATE TABLE [core].[MenusUserProfile];
                TRUNCATE TABLE [core].[menus];
            ");
        }
    }
}
