using Adapters.Context;
using Adapters.Repositories.Core.Menus;
using Adapters.Repositories.Settings.Users;
using Application.Exceptions.Context;
using Application.Features.Settings.Users.Queries.GetUserRoles;
using Application.Wrappers;
using Domain.Enums.Settings.Users;
using MediatR;

namespace Application.Features.Core.Menus.Queries.GetMenuProfiles
{
    public class GetMenusProfileHandler : IRequestHandler<GetMenusProfileQuery, Response<IEnumerable<int>>>
    {
        private readonly IMenuUserProfileRepository _menuUserProfileRepository;

        public GetMenusProfileHandler(IMenuUserProfileRepository menuUserProfileRepository)
        {
            _menuUserProfileRepository = menuUserProfileRepository;
        }

        public async Task<Response<IEnumerable<int>>> Handle(GetMenusProfileQuery query,
            CancellationToken cancellationToken)
        {
            var menus = await _menuUserProfileRepository.ListByUserProfileAsync(query.ProfileEnum);

            return new Response<IEnumerable<int>>(menus.Select(x => x.MenuId));
        }
    }
}