using Domain.Enums.Settings.Checklist.QuestionMaintenance.Questions;

namespace DTO.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Tips { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public QuestionTypeEnum QuestionType { get; set; }
        public bool Required { get; set; }
        public bool EnableNotApply { get; set; }
        public bool RequireSelfInspection { get; set; }
        public bool RequireValidation { get; set; }

    }
}