using Adapters.Services.Core.Menus;
using Application.Wrappers;
using DTO.Core.Menus;
using MediatR;

namespace Application.Features.Core.Menus.Queries.GetMenuToNavigation
{
    public class GetMenuToNavigationHandler : IRequestHandler<GetMenuToNavigationQuery, Response<NavigationDto>>
    {
        private readonly IMenuService _menuService;

        public GetMenuToNavigationHandler(
            IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<Response<NavigationDto>> Handle(GetMenuToNavigationQuery query,
            CancellationToken cancellationToken)
        {
            return new Response<NavigationDto>(await _menuService.GetToNavigation());
        }
    }
}