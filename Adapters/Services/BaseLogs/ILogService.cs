using Domain.Entities.BaseLogs;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Adapters.Services.BaseLogs
{
    public interface ILogService
    {
        Task<Log?> GetLastSpecificLog(string source, string owner);
        Task<Log?> GetLastSpecificLog(string source, string owner, string action);
        Task<Log?> GetLastSpecificLog(string source, string owner, string action, string reference);
        Task<Log> CREATES_SETTINGS_ISSUE(Issue issue);
        Task<Log> UPDATES_SETTINGS_ISSUE(Issue issue);
        Task<Log> CREATES_SETTINGS_ISSUE_TAGS(IssueTag issueTag);
        Task<Log> DELETES_SETTINGS_ISSUE_TAGS(IssueTag issueTag);
        Task<Log> CREATES_SETTINGS_RECOMMENDATION(Recommendation recommendation);
        Task<Log> UPDATES_SETTINGS_RECOMMENDATION(Recommendation recommendation);
        Task<Log> DELETES_SETTINGS_RECOMMENDATION(Recommendation recommendation);
        Task<Log> APPROVES_SETTINGS_RECOMMENDATION(Recommendation recommendation);
        Task<Log> DISAPPROVES_SETTINGS_RECOMMENDATION(Recommendation recommendation);
        Task<Log> LINKS_SETTINGS_RECOMMENDATION_ISSUE(RecommendationVersionIssue recommendationVersionIssue);
        Task<Log> UNLINKS_SETTINGS_RECOMMENDATION_ISSUE(RecommendationVersionIssue recommendationVersionIssue);
        Task<Log> DRAFT_SETTINGS_INSPECTION(Inspection inspection);
        Task<Log> SCHEDULED_SETTINGS_INSPECTION(Inspection inspection);
        Task<Log> UPDATE_SCHEDULED_SETTINGS_INSPECTION(Inspection inspection);
        Task<Log> IN_PROGRESS_SETTINGS_INSPECTION(Inspection inspection);
        Task<Log> WAITING_ANALISYS_SETTINGS_INSPECTION(Inspection inspection);
        Task<Log> CONCLUDED_SETTINGS_INSPECTION(Inspection inspection);
        Task<Log> CANCELED_SETTINGS_INSPECTION(Inspection inspection);
    }
}
