using DTO.Settings.Checklist.RecommendationsCore.Recommendations;

namespace DTO.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionRecommendationsDTO
    {
        public int Id { get; set; }
        public QuestionVersionDTO? QuestionVersion { get; set; }
        public RecommendationDTO? Recommendation { get; set; }
    }
}