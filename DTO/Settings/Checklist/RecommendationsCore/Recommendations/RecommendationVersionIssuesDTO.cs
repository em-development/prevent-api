using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace DTO.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionIssuesDTO
    {
        public int Id { get; set; }
        public RecommendationVersionDTO? RecommendationVersion { get; set; }
        public IssueDTO? Issue { get; set; }
    }
}