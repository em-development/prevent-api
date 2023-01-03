using DTO.Settings.Checklist.AnswerMaintenance.Answers;

namespace DTO.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionAnswersDTO
    {
        public int Id { get; set; }
        public QuestionVersionDTO? QuestionVersion { get; set; }
        public AnswerDTO? Answer { get; set; }
    }
}