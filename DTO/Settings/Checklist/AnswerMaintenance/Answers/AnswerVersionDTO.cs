using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace DTO.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerVersionDTO
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int Version { get; set; }
        public string Description { get; set; } = string.Empty;
        public IEnumerable<IssueDTO>? Issues { get; set; }
    }
}