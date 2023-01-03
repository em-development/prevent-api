namespace DTO.Core.Menus
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Type { get; set; }
        public string? Icon { get; set; }
        public string? Link { get; set; }
        public int? ParentId { get; set; }

        public IEnumerable<MenuDto>? Children { get; set; }
    }
}
