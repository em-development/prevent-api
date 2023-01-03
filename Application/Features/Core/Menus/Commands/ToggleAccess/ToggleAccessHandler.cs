using Adapters.Repositories.Core.Menus;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Core;
using Domain.Enums.Settings.Users;
using MediatR;

namespace Application.Features.Core.Menus.Commands.ToggleAccess
{
    internal class ToggleAccessHandler : IRequestHandler<ToggleAccessRequest, Response<IEnumerable<int>>>
    {
        private readonly IMenuUserProfileRepository _menuUserProfileRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public ToggleAccessHandler(
            IMapper mapper,
            IMenuUserProfileRepository menuUserProfileRepository,
            IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuUserProfileRepository = menuUserProfileRepository;
            _menuRepository = menuRepository;
        }

        public async Task<Response<IEnumerable<int>>> Handle(
            ToggleAccessRequest request,
            CancellationToken cancellationToken)
        {
            await RecursiveToggle(request.MenuId, request.ProfileEnum);
            
            var menus = await _menuUserProfileRepository.ListByUserProfileAsync(request.ProfileEnum);
            
            return new Response<IEnumerable<int>>(_mapper.Map<IEnumerable<int>>(menus.Select(x => x.MenuId)));
        }

        private async Task RecursiveToggle(int menuId, UserProfileEnum profileEnum)
        {
            var menuUserProfile =
                await _menuUserProfileRepository.GetByProfileEnumAndMenuIdAsync(menuId,
                    profileEnum);

            if (menuUserProfile == null)
            {
                await _menuUserProfileRepository.InsertAsync(new MenuUserProfile(menuId,
                    profileEnum));
            }
            else
            {
                await _menuUserProfileRepository.RemoveAsync(menuUserProfile);
            }

            var menu = await _menuRepository.GetByIdAsync(menuId);

            if (menu?.ParentId != null)
            {
                await RecursiveToggle((int) menu.ParentId, profileEnum);
            }
        }
    }
}