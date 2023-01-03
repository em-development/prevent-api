using Application.Wrappers;
using Domain.Enums.Settings.Users;
using MediatR;

namespace Application.Features.Core.Menus.Queries.GetMenuProfiles
{
    public class GetMenusProfileQuery : IRequest<Response<IEnumerable<int>>>
    {
        public UserProfileEnum ProfileEnum { get; set; }
    }
}