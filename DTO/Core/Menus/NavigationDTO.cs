namespace DTO.Core.Menus
{
    public class NavigationDto
    {
        public IEnumerable<MenuDto> Compact { get; set; } = new List<MenuDto>();
        public IEnumerable<MenuDto> Default { get; set; } = new List<MenuDto>();
        public IEnumerable<MenuDto> Futuristic { get; set; } = new List<MenuDto>();
        public IEnumerable<MenuDto> Horizontal { get; set; } = new List<MenuDto>();
    }
}
