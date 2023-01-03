using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace DTO.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerVersionIssuesDTO
    {
        public int Id { get; set; }
        public AnswerVersionDTO? AnswerVersion { get; set; }
        public IssueDTO? Issue { get; set; }
    }
}