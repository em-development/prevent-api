using Adapters.Repositories.BaseLogs;
using Adapters.Repositories.Core.Menus;
using Adapters.Repositories.Files;
using Adapters.Repositories.Inspections.Inspections;
using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts;
using Adapters.Repositories.Settings.LegalEntityCore.LegalEntitySyncs;
using Adapters.Repositories.Settings.PropertyCore.Properties;
using Adapters.Repositories.Settings.PropertyCore.PropertySyncs;
using Adapters.Repositories.Settings.Users;
using CC.Repository.BaseLogs;
using Microsoft.Extensions.DependencyInjection;
using Repository.BaseLogs;
using Repository.Core.Menus;
using Repository.Inspections.Inspections;
using Repository.Settings.Checklist.AnswerMaintenance.Answers;
using Repository.Settings.Checklist.ChecklistMaintenance;
using Repository.Settings.Checklist.QuestionMaintenance.Questions;
using Repository.Settings.Checklist.RecommendationsCore.Issues;
using Repository.Settings.Checklist.RecommendationsCore.Recommendations;
using Repository.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Repository.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Repository.Settings.Inspections.InspectionMaintenance.Inspections;
using Repository.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Repository.Settings.LegalEntityCore.LegalEntities;
using Repository.Settings.LegalEntityCore.LegalEntityContacts;
using Repository.Settings.LegalEntityCore.LegalEntitySyncs;
using Repository.Settings.PropertyCore.Properties;
using Repository.Settings.PropertyCore.PropertySyncs;
using Repository.Settings.Users;

namespace IoC.DependencyInjections
{
    internal static class RepositoriesDependenciesInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompactUserRepository, CompactUserRepository>()
                .AddScoped<ICompactInspectionRepository, CompactInspectionRepository>()
                .AddScoped<IAttachmentRepository, AttachmentRepository>()
                .AddScoped<ILogRepository, LogRepository>()
                .AddScoped<ILogContentRepository, LogContentRepository>()
                .AddScoped<IIssueRepository, IssueRepository>()
                .AddScoped<IIssueTagRepository, IssueTagRepository>()
                .AddScoped<IAnswerRepository, AnswerRepository>()
                .AddScoped<IAnswerVersionRepository, AnswerVersionRepository>()
                .AddScoped<IAnswerVersionIssuesRepository, AnswerVersionIssuesRepository>()
                .AddScoped<IChecklistRepository, ChecklistRepository>()
                .AddScoped<IChecklistVersionRepository, ChecklistVersionRepository>()
                .AddScoped<IChecklistVersionQuestionsRepository, ChecklistVersionQuestionsRepository>()
                .AddScoped<IInspectionRepository, InspectionRepository>()
                .AddScoped<IInspectionResponsableRepository, InspectionResponsableRepository>()
                .AddScoped<IInspectionPropertyCoverageRepository, InspectionPropertyCoverageRepository>()
                .AddScoped<IInspectionPropertyBuildingRepository, InspectionPropertyBuildingRepository>()
                .AddScoped<IInspectionAnswerRepository, InspectionAnswerRepository>()
                .AddScoped<IInspectionAnswerVersionRepository, InspectionAnswerVersionRepository>()
                .AddScoped<IInspectionAnswerCustomRepository, InspectionAnswerCustomRepository>()
                .AddScoped<IInspectionTemplateRepository, InspectionTemplateRepository>()
                .AddScoped<IInspectionTemplateVersionRepository, InspectionTemplateVersionRepository>()
                .AddScoped<IInspectionTemplateVersionChecklistsRepository,
                    InspectionTemplateVersionChecklistsRepository>()
                .AddScoped<IInspectionTemplateVersionPropertyTypesRepository,
                    InspectionTemplateVersionPropertyTypesRepository>()
                .AddScoped<ILegalEntityRepository, LegalEntityRepository>()
                .AddScoped<ILegalEntityContactRepository, LegalEntityContactRepository>()
                .AddScoped<ILegalEntitySyncRepository, LegalEntitySyncRepository>()
                .AddScoped<IPropertyRepository, PropertyRepository>()
                .AddScoped<IPropertySyncRepository, PropertySyncRepository>()
                .AddScoped<IRecommendationRepository, RecommendationRepository>()
                .AddScoped<IRecommendationAttachmentRepository, RecommendationAttachmentRepository>()
                .AddScoped<IRecommendationVersionRepository, RecommendationVersionRepository>()
                .AddScoped<IRecommendationVersionIssuesRepository, RecommendationVersionIssuesRepository>()
                .AddScoped<IQuestionRepository, QuestionRepository>()
                .AddScoped<IQuestionVersionRepository, QuestionVersionRepository>()
                .AddScoped<IQuestionVersionAnswersRepository, QuestionVersionAnswersRepository>()
                .AddScoped<IQuestionVersionRecommendationsRepository, QuestionVersionRecommendationsRepository>()
                .AddScoped<ISubQuestionVersionsRepository, SubQuestionVersionsRepository>()
                .AddScoped<IUsersRepository, UsersRepository>()
                .AddScoped<IUsersProfilesRepository, UsersProfilesRepository>()
                .AddScoped<IUsersLegalEntitiesRepository, UsersLegalEntitiesRepository>()
                .AddScoped<IMenuRepository, MenuRepository>()
                .AddScoped<IMenuUserProfileRepository, MenuUserProfileRepository>()
                .AddScoped<IInspectionAttachmentRepository, InspectionAttachmentRepository>();
            return services;
        }
    }
}