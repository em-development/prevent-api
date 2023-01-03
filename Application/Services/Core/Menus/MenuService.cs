using Adapters.Context;
using Adapters.Repositories.Core.Menus;
using Adapters.Services.Core.Menus;
using Application.Exceptions.Common;
using AutoMapper;
using Domain.Entities.Core;
using DTO.Core.Menus;

namespace Application.Services.Core.Menus
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly ISessionContext _sessionContext;

        private IEnumerable<Menu>? _allMenus;

        public MenuService(
            IMenuRepository menuRepository,
            IMapper mapper, ISessionContext sessionContext)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _sessionContext = sessionContext;
        }

        public async Task<NavigationDto> GetToNavigation()
        {
            if (_sessionContext.UserSession == null)
            {
                throw new NotFoundException("api-entity-session-user");
            }

            _allMenus = await _menuRepository.ListByUser(_sessionContext.UserSession.Id);

            var tree = await GetTreeToNavigation(_allMenus.Where(x => x.ParentId == null));

            NavigationDto navigation = new()
            {
                Compact = tree,
                Default = tree,
                Futuristic = tree,
                Horizontal = tree
            };

            return navigation;
        }

        private async Task<IEnumerable<MenuDto>> GetTreeToNavigation(IEnumerable<Menu> menus)
        {
            IList<MenuDto> result = new List<MenuDto>();

            foreach (var menu in menus)
            {
                var menuDto = _mapper.Map<MenuDto>(menu);

                if (_allMenus != null)
                {
                    menuDto.Children = await GetTreeToNavigation(_allMenus.Where(x => x.ParentId == menu.Id));
                }

                result.Add(menuDto);
            }

            return result;
        }
    }
}