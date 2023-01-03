using DTO.Settings.Checklist.AnswerMaintenance.Answers;

namespace DTO.Settings.Inspections.InspectionMaintenance.InspectionAnswers
{
    public class InspectionAnswerVersionDTO
    {
        public int Id { get; set; }
        public AnswerVersionDTO? AnswerVersion { get; set; }
    }
}