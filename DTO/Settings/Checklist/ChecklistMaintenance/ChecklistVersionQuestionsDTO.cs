using DTO.Settings.Checklist.QuestionMaintenance.Questions;

namespace DTO.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersionQuestionsDTO
    {
        public int Id { get; set; }
        public ChecklistVersionDTO? ChecklistVersion { get; set; }
        public QuestionDTO? Question { get; set; }
    }
}