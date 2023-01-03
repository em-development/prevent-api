using Application.Wrappers;
using Domain.Enums.Settings.Users;
using MediatR;

namespace Application.Features.Core.Menus.Commands.ToggleAllAccess
{
    public class ToggleAllAccessRequest : IRequest<Response<IEnumerable<int>>>
    {
        public UserProfileEnum ProfileEnum { get; set; }
        public bool Status { get; set; }
    }
}