using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Files;
using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace DTO.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionDTO
    {
        public int Id { get; set; }
        public int RecommendationId { get; set; }
        public int Version { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string DueDateText { get; set; } = string.Empty;
        public RecommendationVersionStatusEnum Status { get; set; }
        public IEnumerable<IssueDTO>? Issues { get; set; }
        public IEnumerable<AttachmentDto>? Attachments { get; set; }
    }
}