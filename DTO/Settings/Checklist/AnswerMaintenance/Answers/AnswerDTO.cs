using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace DTO.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}