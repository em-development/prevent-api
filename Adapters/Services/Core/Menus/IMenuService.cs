using DTO.Core.Menus;

namespace Adapters.Services.Core.Menus
{
    public interface IMenuService
    {
        //Task<IEnumerable<MenuToFormDto>> GetToForm();
        Task<NavigationDto> GetToNavigation();
    }
}
