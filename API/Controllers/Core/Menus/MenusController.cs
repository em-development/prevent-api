using API.Controllers.Base;
using Application.Features.Core.Menus.Commands.ToggleAccess;
using Application.Features.Core.Menus.Commands.ToggleAllAccess;
using Application.Features.Core.Menus.Queries.GetMenuProfiles;
using Application.Wrappers;
using Domain.Enums.Settings.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Core.Menus
{
    [Route("[controller]")]
    [ApiController]
    public class MenusController : BaseController
    {
        [HttpGet]
        [Route("allowed/{profileEnum:int}")]
        public async Task<ActionResult<Response<IEnumerable<int>>>> GetAllowedByProfile(int profileEnum)
        {
            var query = new GetMenusProfileQuery
            {
                ProfileEnum = (UserProfileEnum) profileEnum
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Response<IEnumerable<IEnumerable<int>>>>> AllowRole(
            [FromBody] ToggleAccessRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("all")]
        public async Task<ActionResult<Response<IEnumerable<IEnumerable<int>>>>> AllowAllRole(
            [FromBody] ToggleAllAccessRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}