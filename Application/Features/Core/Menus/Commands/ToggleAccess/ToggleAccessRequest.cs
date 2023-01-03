using Application.Wrappers;
using Domain.Enums.Settings.Users;
using MediatR;

namespace Application.Features.Core.Menus.Commands.ToggleAccess
{
    public class ToggleAccessRequest : IRequest<Response<IEnumerable<int>>>
    {
        public UserProfileEnum ProfileEnum { get; set; }
        public int MenuId { get; set; }
    }
}
