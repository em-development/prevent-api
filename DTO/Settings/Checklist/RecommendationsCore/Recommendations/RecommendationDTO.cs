using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;

namespace DTO.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationDTO
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string DueDateText { get; set; } = string.Empty;
        public RecommendationVersionStatusEnum Status { get; set; }
    }
}