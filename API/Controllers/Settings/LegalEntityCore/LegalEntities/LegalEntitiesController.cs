using API.Controllers.Base;
using Application.Features.Settings.LegalEntityCore.LegalEntities.Commands;
using Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.GetById;
using Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.Search;
using Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.SearchSync;
using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.LegalEntityCore.LegalEntities
{
    [Route("legal-entity-core/legal-entities")]
    [ApiController]
    public class LegalEntitiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<LegalEntityDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response<LegalEntityDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<Response<LegalEntityDTO>>> GetAll([FromQuery] GetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        #region LegalEntity Sync

        [HttpGet]
        [Route("search-sync")]
        public async Task<ActionResult<PagedResponse<IEnumerable<LegalEntitySyncDTO>>>> SearchSync(
           [FromQuery] SearchSyncQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut]
        [Route("sync-entities")]
        public async Task<ActionResult<List<LegalEntityDTO>>> SyncEntities(
            [FromBody] UpdateLegalEntitySyncRequest query)
        {
            return Ok(await Mediator.Send(query));
        } 

        #endregion
    }
}