using Application.Wrappers;
using DTO.Core.Menus;
using MediatR;

namespace Application.Features.Core.Menus.Queries.GetMenuToNavigation
{
    public class GetMenuToNavigationQuery : IRequest<Response<NavigationDto>>
    {
    }
}