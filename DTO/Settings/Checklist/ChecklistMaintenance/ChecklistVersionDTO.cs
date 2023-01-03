
using DTO.Settings.Checklist.QuestionMaintenance.Questions;

namespace DTO.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersionDTO
    {
        public int Id { get; set; }
        public int ChecklistId { get; set; }
        public int Version { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public IEnumerable<QuestionVersionDTO>? Questions { get; set; }
    }
}