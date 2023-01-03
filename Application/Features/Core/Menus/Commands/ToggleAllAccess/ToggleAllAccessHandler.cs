using Adapters.Context;
using Adapters.Repositories.Core.Menus;
using Application.Exceptions.Context;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Features.Core.Menus.Commands.ToggleAllAccess
{
    internal class ToggleAllAccessHandler : IRequestHandler<ToggleAllAccessRequest, Response<IEnumerable<int>>>
    {
        private readonly IMenuUserProfileRepository _menuUserProfileRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly ISessionContext _sessionContext;

        public ToggleAllAccessHandler(
            IMapper mapper,
            IMenuUserProfileRepository menuUserProfileRepository,
            IMenuRepository menuRepository, ISessionContext sessionContext)
        {
            _mapper = mapper;
            _menuUserProfileRepository = menuUserProfileRepository;
            _menuRepository = menuRepository;
            _sessionContext = sessionContext;
        }

        public async Task<Response<IEnumerable<int>>> Handle(
            ToggleAllAccessRequest request,
            CancellationToken cancellationToken)
        {
            if (_sessionContext.UserSession == null)
            {
                throw new UserNotRegisteredInSessionException();
            }

            var allAllowedMenus = await _menuRepository.ListByUser(_sessionContext.UserSession.Id);

            allAllowedMenus = allAllowedMenus.ToList();

            foreach (var menu in allAllowedMenus)
            {
                var menuUserProfile = await
                    _menuUserProfileRepository.GetByProfileEnumAndMenuIdAsync(menu.Id, request.ProfileEnum);

                if (request.Status)
                {
                    if (menuUserProfile == null)
                    {
                        await _menuUserProfileRepository.InsertAsync(new MenuUserProfile(menu.Id,
                            request.ProfileEnum));
                    }
                }
                else
                {
                    if (menuUserProfile != null)
                    {
                        await _menuUserProfileRepository.RemoveAsync(menuUserProfile);
                    }
                }
            }

            var menus = await _menuUserProfileRepository.ListByUserProfileAsync(request.ProfileEnum);

            return new Response<IEnumerable<int>>(_mapper.Map<IEnumerable<int>>(menus.Select(x => x.MenuId)));
        }
    }
}