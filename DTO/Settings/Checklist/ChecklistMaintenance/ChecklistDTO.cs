
namespace DTO.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistDTO
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
    }
}