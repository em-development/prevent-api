using API.Controllers.Base;
using Application.Features.Settings.PropertyCore.Properties.Commands;
using Application.Features.Settings.PropertyCore.Properties.Queries.GetById;
using Application.Features.Settings.PropertyCore.Properties.Queries.GetByInspectionTemplateVersionId;
using Application.Features.Settings.PropertyCore.Properties.Queries.GetPropertyTypes;
using Application.Features.Settings.PropertyCore.Properties.Queries.Search;
using Application.Features.Settings.PropertyCore.Properties.Queries.SearchSync;
using Application.Wrappers;
using DTO.Settings.PropertyCore.Properties;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.PropertyCore.Properties
{
    [Route("property-core/properties")]
    [ApiController]
    public class PropertiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<PropertyDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response<PropertyDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("search-by-legal-entity")]
        public async Task<ActionResult<PagedResponse<IEnumerable<PropertyDTO>>>> SearchByLegalEntityId(
            [FromQuery] SearchByLegalEntityIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        #region Property Sync

        [HttpGet]
        [Route("search-sync")]
        public async Task<ActionResult<PagedResponse<IEnumerable<PropertySyncDTO>>>> SearchSync(
           [FromQuery] SearchSyncQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut]
        [Route("sync-properties")]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> SyncProperties(
            [FromBody] UpdatePropertySyncRequest query)
        {
            return Ok(await Mediator.Send(query));
        }

        #endregion

        [HttpGet]
        [Route("get-types")]
        public async Task<ActionResult<Response<PropertyTypeDTO>>> GetPropertyTypes([FromQuery] GetPropertyTypesQuery query, int id)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("get-by-inspection-template-version-id/{id}")]
        public async Task<ActionResult<Response<IEnumerable<int>?>>> GetByInspectionTemplateVersionId([FromQuery] GetByInspectionTemplateVersionIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
    }
}