using API.Controllers.Base;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.CreateLegalEntityContact;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.DeleteLegalEntityContact;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.UpdateLegalEntityContact;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Queries.GetById;
using Application.Features.Settings.Users.Queries.GetInspectors;
using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.LegalEntityCore.LegalEntityContacts
{
    [Route("legal-entity-core/contact")]
    [ApiController]
    public class LegalEntityContactControllerController : BaseController
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<LegalEntityContactDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("get-by-legal-entity-id/{id:int}")]
        public async Task<ActionResult<Response<IEnumerable<LegalEntityContactDTO>>>> GetByLegalEntityId([FromQuery] GetByLegalEntityIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<LegalEntityContactDTO>>> Create(
            [FromBody] CreateLegalEntityContactRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<LegalEntityContactDTO>>> Update(
            [FromBody] UpdateLegalEntityContactRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<bool>>> Delete(
            int id)
        {
            return Ok(await Mediator.Send(new DeleteLegalEntityContactRequest() { Id = id}));
        }
    }
}