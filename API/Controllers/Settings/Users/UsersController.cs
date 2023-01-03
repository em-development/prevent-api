using API.Controllers.Base;
using Application.Features.Settings.Users.Commands.CreateUser;
using Application.Features.Settings.Users.Commands.DeleteUser;
using Application.Features.Settings.Users.Commands.UpdateUser;
using Application.Features.Settings.Users.Queries.GetById;
using Application.Features.Settings.Users.Queries.GetInspectors;
using Application.Features.Settings.Users.Queries.Search;
using Application.Wrappers;
using DTO.Settings.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Users
{
    [Route("users-core/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<UserDto>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<UserFormDto>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<UserFormDto>>> Create(
            [FromBody] CreateUserRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<UserFormDto>>> Update(
            [FromBody] UpdateUserRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<bool>>> Delete(
            int id)
        {
            return Ok(await Mediator.Send(new DeleteUserRequest() { Id = id }));
        }

        [HttpGet]
        [Route("get-inspectors-by-legal-entity-id/{id:int}")]
        public async Task<ActionResult<Response<IEnumerable<UserDto>>>> GetInspectors([FromQuery] GetInspectorsQuery query, int id)
        {
            query.Id = id;
            return Ok(await Mediator.Send(query));
        }
    }
}