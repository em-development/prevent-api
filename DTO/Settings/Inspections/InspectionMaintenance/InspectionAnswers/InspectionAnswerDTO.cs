using DTO.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;

namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswerDTO
    {
        public int Id { get; set; }
        public ChecklistVersionDTO? ChecklistVersion { get; set; }
        public QuestionVersionDTO? QuestionVersion { get; set; }
    }
}