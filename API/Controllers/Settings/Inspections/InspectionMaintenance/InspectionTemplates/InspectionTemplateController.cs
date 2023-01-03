using API.Controllers.Base;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.Search;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.SearchSideForm;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.GetById;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.GetByIdToForm;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Commands.CreateInspectionTemplate;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Commands.UpdateInspectionTemplate;
using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.SearchByPropertyTypeId;

namespace API.Controllers.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    [Route("inspection-maintenance/inspection-template")]
    [ApiController]
    public class InspectionTemplateController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<InspectionTemplateDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("side-form")]
        public async Task<ActionResult<PagedResponse<IEnumerable<InspectionTemplateFormDTO>>>> Search(
            [FromQuery] SearchSideFormQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<InspectionTemplateDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("search-by-property-type")]
        public async Task<ActionResult<Response<InspectionTemplateDTO>>> SearchByPropertyTypeId([FromQuery] SearchByPropertyTypeIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}/to-form")]
        public async Task<ActionResult<Response<InspectionTemplateFormDTO>>> GetByIdToForm([FromQuery] GetByIdToFormQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<InspectionTemplateDTO>>> Create(
            [FromBody] CreateInspectionTemplateRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<InspectionTemplateDTO>>> Update(
            [FromBody] UpdateInspectionTemplateRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }
    }
}
