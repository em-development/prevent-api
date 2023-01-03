using DTO.Settings.Checklist.RecommendationsCore.Recommendations;

namespace DTO.Settings.Checklist.QuestionMaintenance.Questions
{
    public class SubQuestionVersionsDTO
    {
        public int Id { get; set; }
        public QuestionVersionDTO? Version { get; set; }
        public QuestionVersionDTO? SubQuestionVersion { get; set; }
    }
}