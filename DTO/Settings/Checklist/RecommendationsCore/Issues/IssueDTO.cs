namespace DTO.Settings.Checklist.RecommendationsCore.Issues
{
    public class IssueDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string[] Tags { get; set; } = Array.Empty<string>();

        //public IEnumerable<RecommendationVersionDTO>? RecommendationsVersion { get; set; }

        public bool IsActive { get; set; }
    }
}