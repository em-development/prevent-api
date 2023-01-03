using Adapters.Context;
using Adapters.Repositories.BaseLogs;
using Adapters.Services.BaseLogs;
using Domain.Entities.BaseLogs;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Identifiers.BaseLogs;

namespace CC.Application.Services.BaseLogs
{
    public class LogService : ILogService
    {
        private readonly ISessionContext _sessionContext;
        private readonly ILogRepository _logRepository;
        private readonly ILogContentRepository _logContentRepository;

        public LogService(
            ISessionContext sessionContext,
            ILogRepository logRepository,
            ILogContentRepository logContentRepository)
        {
            _sessionContext = sessionContext;
            _logRepository = logRepository;
            _logContentRepository = logContentRepository;
        }

        public async Task<Log?> GetLastSpecificLog(string source, string owner)
        {
            return await _logRepository.GetLastSpecificLog(source, owner);
        }

        public async Task<Log?> GetLastSpecificLog(string source, string owner, string action)
        {
            return await _logRepository.GetLastSpecificLog(source, owner, action);
        }

        public async Task<Log?> GetLastSpecificLog(string source, string owner, string action, string reference)
        {
            return await _logRepository.GetLastSpecificLog(source, owner, action, reference);
        }

        private async Task<Log> InsertAsync(Log log, object? content = null)
        {
            await _logRepository.InsertAsync(log);

            if (content != null && log.Action != LogActionType.DELETED.Value)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(content);

                LogContent logContent = new LogContent(log.Id, json);

                await _logContentRepository.InsertAsync(logContent);
            }

            return log;
        }

        #region SETTINGS_ISSUE
        private async Task<Log> SETTINGS_ISSUE(
            Issue issue,
            LogActionType action
        )
        {
            return await InsertAsync(new
            (
                source: LogSouceType.SETTINGS_ISSUE.Value,
                owner: issue.Id.ToString(),
                reference: null,
                action: action.Value,
                userId: _sessionContext.UserSession?.Id ?? 1
            ), issue.GetToLog()); ;
        }

        public async Task<Log> CREATES_SETTINGS_ISSUE(
            Issue issue
        )
        {
            return await SETTINGS_ISSUE(
                issue,
                LogActionType.CREATED
            );
        }

        public async Task<Log> UPDATES_SETTINGS_ISSUE(
            Issue issue
        )
        {
            return await SETTINGS_ISSUE(
                issue,
                LogActionType.UPDATED
            );
        }
        #endregion SETTINGS_ISSUE

        #region SETTINGS_ISSUE_TAGS
        private async Task<Log> SETTINGS_ISSUE_TAGS(
            IssueTag issueTag,
            LogActionType action
        )
        {
            return await InsertAsync(new
            (
                source: LogSouceType.SETTINGS_ISSUE_TAGS.Value,
                owner: issueTag.Id.ToString(),
                reference: null,
                action: action.Value,
                userId: _sessionContext.UserSession?.Id ?? 1
            ), issueTag.GetToLog()); ;
        }

        public async Task<Log> CREATES_SETTINGS_ISSUE_TAGS(
            IssueTag issueTag
        )
        {
            return await SETTINGS_ISSUE_TAGS(
                issueTag,
                LogActionType.CREATED
            );
        }

        public async Task<Log> DELETES_SETTINGS_ISSUE_TAGS(
            IssueTag issueTag
        )
        {
            return await SETTINGS_ISSUE_TAGS(
                issueTag,
                LogActionType.DELETED
            );
        }
        #endregion SETTINGS_ISSUE

        #region SETTING_RECOMMENDATION
        private async Task<Log> SETTINGS_RECOMMENDATION(
            Recommendation recommendation,
            LogActionType action
        )
        {
            return await InsertAsync(new
            (
                source: LogSouceType.SETTINGS_RECOMMENDATION.Value,
                owner: recommendation.VersionId.ToString(),
                reference: recommendation.Id.ToString(),
                action: action.Value,
                userId: _sessionContext.UserSession?.Id ?? 1
            )); ;
        }

        public async Task<IEnumerable<Log?>> GetByRecommendationId(int recommendationId)
        {
            return await _logRepository.GetByRecommendationId(recommendationId);
        }

        public async Task<Log> CREATES_SETTINGS_RECOMMENDATION(
            Recommendation recommendation
        )
        {
            return await SETTINGS_RECOMMENDATION(
                recommendation,
                LogActionType.CREATED
            );
        }

        public async Task<Log> UPDATES_SETTINGS_RECOMMENDATION(
            Recommendation recommendation
        )
        {
            return await SETTINGS_RECOMMENDATION(
                recommendation,
                LogActionType.UPDATED
            );
        }

        public async Task<Log> DELETES_SETTINGS_RECOMMENDATION(
            Recommendation recommendation
        )
        {
            return await SETTINGS_RECOMMENDATION(
                recommendation,
                LogActionType.DELETED
            );
        }

        public async Task<Log> APPROVES_SETTINGS_RECOMMENDATION(
            Recommendation recommendation
        )
        {
            return await SETTINGS_RECOMMENDATION(
                recommendation,
                LogActionType.APPROVED
            );
        }

        public async Task<Log> DISAPPROVES_SETTINGS_RECOMMENDATION(
            Recommendation recommendation
        )
        {
            return await SETTINGS_RECOMMENDATION(
                recommendation,
                LogActionType.DISAPPROVED
            );
        }
        #endregion

        #region SETTINGS_RECOMMENDATION_ISSUES
        private async Task<Log> SETTINGS_RECOMMENDATION_ISSUE(
           RecommendationVersionIssue recommendationVersionIssue,
           LogActionType action
       )
        {
            return await InsertAsync(new
            (
                source: LogSouceType.SETTINGS_RECOMMENDATION_ISSUES.Value,
                owner: recommendationVersionIssue.RecommendationVersionId.ToString(),
                reference: recommendationVersionIssue.IssueId.ToString(),
                action: action.Value,
                userId: _sessionContext.UserSession?.Id ?? 1
            )); ;
        }

        public async Task<Log> LINKS_SETTINGS_RECOMMENDATION_ISSUE(
            RecommendationVersionIssue recommendationVersionIssue
        )
        {
            return await SETTINGS_RECOMMENDATION_ISSUE(
                recommendationVersionIssue,
                LogActionType.LINKED
            );
        }

        public async Task<Log> UNLINKS_SETTINGS_RECOMMENDATION_ISSUE(
            RecommendationVersionIssue recommendationVersionIssue
        )
        {
            return await SETTINGS_RECOMMENDATION_ISSUE(
                recommendationVersionIssue,
                LogActionType.UNLINKED
            );
        }
        #endregion

        #region SETTINGS_INSPECTION
        private async Task<Log> SETTINGS_INSPECTION(
           Inspection inspection,
           LogActionType action
       )
        {
            return await InsertAsync(new
            (
                source: LogSouceType.SETTINGS_INSPECTIONS.Value,
                owner: inspection.Id.ToString(),
                reference: null,
                action: action.Value,
                userId: _sessionContext.UserSession?.Id ?? 1
            )); ;
        }

        public async Task<Log> DRAFT_SETTINGS_INSPECTION(
            Inspection inspection
        )
        {
            return await SETTINGS_INSPECTION(
                inspection,
                LogActionType.DRAFT
            );
        }

        public async Task<Log> SCHEDULED_SETTINGS_INSPECTION(
            Inspection inspection
        )
        {
            return await SETTINGS_INSPECTION(
                inspection,
                LogActionType.SCHEDULED
            );
        }

        public async Task<Log> UPDATE_SCHEDULED_SETTINGS_INSPECTION(
            Inspection inspection
        )
        {
            return await SETTINGS_INSPECTION(
                inspection,
                LogActionType.UPDATE_SCHEDULED
            );
        }

        public async Task<Log> IN_PROGRESS_SETTINGS_INSPECTION(
            Inspection inspection
        )
        {
            return await SETTINGS_INSPECTION(
                inspection,
                LogActionType.IN_PROGRESS
            );
        }

        public async Task<Log> WAITING_ANALISYS_SETTINGS_INSPECTION(
            Inspection inspection
        )
        {
            return await SETTINGS_INSPECTION(
                inspection,
                LogActionType.WAITING_ANALISYS
            );
        }

        public async Task<Log> CONCLUDED_SETTINGS_INSPECTION(
            Inspection inspection
        )
        {
            return await SETTINGS_INSPECTION(
                inspection,
                LogActionType.CONCLUDED
            );
        }

        public async Task<Log> CANCELED_SETTINGS_INSPECTION(
            Inspection inspection
        )
        {
            return await SETTINGS_INSPECTION(
                inspection,
                LogActionType.CANCELED
            );
        }

        #endregion
    }
}
