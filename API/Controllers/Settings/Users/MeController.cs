using Adapters.Context;
using API.Controllers.Base;
using Application.Features.Core.Menus.Queries.GetMenuToNavigation;
using Application.Features.Settings.Users.Queries.GetUserRoles;
using Application.Wrappers;
using Domain.Enums.Settings.Users;
using DTO.Core.Menus;
using DTO.Settings.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Users
{
    [Route("user/[controller]")]
    [ApiController]
    public class MeController : BaseController
    {
        private readonly ISessionContext _sessionContext;

        public MeController(ISessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<Response<CompactUserDTO>> GetUser()
        {
            return Ok(new Response<CompactUserDTO?>(this._sessionContext.UserSession));
        }

        [HttpGet]
        [Route("navigation")]
        public async Task<ActionResult<Response<NavigationDto>>> GetNavigation(
            [FromQuery] GetMenuToNavigationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("roles")]
        public async Task<ActionResult<Response<IEnumerable<UserProfileEnum>>>> GetRoles(
            [FromQuery] GetUserRolesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}