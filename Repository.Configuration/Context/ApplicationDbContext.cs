using Domain.Compacts.Settings.Users;
using Domain.Entities.BaseLogs;
using Domain.Entities.Files;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using Domain.Compacts.Settings.Core.Menus;
using Domain.Entities.Core;
using Domain.Entities.Settings.Users;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.Compacts.Settings.Inspections;
using Domain.Entities.Inspections.InspectionAnswers;
using Domain.Entities.Inspections.Inspections;

namespace Repository.Configuration.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region Contructor


        public ApplicationDbContext([NotNull] DbContextOptions options, IConfiguration configuration) : base(options)

        {
            
        }

        #endregion Contructor

        #region Logs.Logs

        public DbSet<Log> Logs { get; private init; }
        public DbSet<LogContent> LogContents { get; private init; }

        #endregion Logs.Logs

        #region Compacts.Core

        public DbSet<MenuUserCompact> MenuPersonCompacts { get; private init; }

        #endregion Compacts.Core

        #region Entities.Core

        public DbSet<Menu> Menus { get; private init; }
        public DbSet<MenuUserProfile> MenuUserProfiles { get; private init; }

        #endregion

        #region Entities.Files

        public DbSet<Attachment> Attachments { get; private init; }

        #endregion Entities.Files

        #region Entities.Settings

        public DbSet<Answer> Answers { get; private init; }
        public DbSet<AnswerVersion> AnswerVersions { get; private init; }
        public DbSet<AnswerVersionIssues> AnswerVersionIssues { get; private init; }
        public DbSet<Checklist> Checklists { get; private init; }
        public DbSet<ChecklistVersion> ChecklistVersions { get; private init; }
        public DbSet<ChecklistVersionQuestions> ChecklistVersionQuestions { get; private init; }
        public DbSet<Inspection> Inspections { get; private init; }
        public DbSet<InspectionAttachment> InspectionAttachments { get; private init; }
        public DbSet<InspectionResponsable> InspectionResponsables { get; private init; }
        public DbSet<InspectionPropertyCoverage> InspectionPropertyCoverages { get; private init; }
        public DbSet<InspectionPropertyBuilding> InspectionPropertyBuildings { get; private init; }
        public DbSet<InspectionAnswer> InspectionAnswers { get; private init; }
        public DbSet<InspectionAnswerAttachment> InspectionAnswerAttachments { get; private init; }
        public DbSet<InspectionAnswerVersion> InspectionAnswerVersions { get; private init; }
        public DbSet<InspectionAnswerCustom> InspectionAnswerCustoms { get; private init; }
        public DbSet<InspectionSchedule> InspectionSchedules { get; private init; }
        public DbSet<InspectionTemplate> InspectionTemplates { get; private init; }
        public DbSet<InspectionTemplateVersion> InspectionTemplateVersions { get; private init; }
        public DbSet<InspectionTemplateVersionChecklists> InspectionTemplateVersionChecklists { get; private init; }
        public DbSet<InspectionTemplateVersionPropertyTypes> InspectionTemplateVersionPropertyTypes { get; private init; }
        public DbSet<Issue> Issues { get; private init; }
        public DbSet<IssueTag> IssueTags { get; private init; }
        public DbSet<LegalEntity> LegalEntities { get; private init; }
        public DbSet<LegalEntitySync> LegalEntitySyncs { get; private init; }
        public DbSet<LegalEntityContact> LegalEntityContacts { get; private init; }
        public DbSet<Property> Properties { get; private init; }
        public DbSet<PropertySync> PropertySyncs { get; private init; }
        public DbSet<PropertyType> PropertyTypes { get; private init; }
        public DbSet<Recommendation> Recommendations { get; private init; }
        public DbSet<RecommendationAttachment> RecommendationAttachments { get; private init; }
        public DbSet<RecommendationVersion> RecommendationVersions { get; private init; }
        public DbSet<RecommendationVersionIssue> RecommendationVersionIssues { get; private init; }
        public DbSet<Question> Questions { get; private init; }
        public DbSet<QuestionVersion> QuestionVersions { get; private init; }
        public DbSet<QuestionVersionAnswers> QuestionVersionAnswers { get; private init; }
        public DbSet<QuestionVersionRecommendations> QuestionVersionRecommendations { get; private init; }
        public DbSet<SubQuestionVersions> SubQuestionVersions { get; private init; }
        public DbSet<User> Users { get; private init; }
        public DbSet<UsersLegalEntities> UsersLegalEntities { get; private init; }
        public DbSet<UsersProfiles> UsersProfiles { get; private init; }

        #endregion Entities.Settings

        #region Compacts.Settings

        public DbSet<CompactUser> CompactUsers { get; private init; }
        public DbSet<CompactInspection> CompactInspections { get; private init; }

        #endregion Compacts.Settings

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}