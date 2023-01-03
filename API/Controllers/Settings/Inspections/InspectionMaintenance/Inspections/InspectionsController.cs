using API.Controllers.Base;
using API.Helpers;
using Application.Features.Inspections.inspections.Commands.SaveInspectionAttachments;
using Application.Features.Inspections.inspections.Queries.ListInspectionAttachments;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetById;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.SearchForInspector;
using Application.Wrappers;
using DTO.Inspections.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Inspections.InspectionMaintenance.Inspections
{
    [Route("inspections/inspections")]
    [ApiController]
    public class InspectionsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<CompactInspectionDTO>>>> Search(
            [FromQuery] SearchForInspectorQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<PagedResponse<IEnumerable<CompactInspectionDTO>>>> GetById([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetByIdQuery() {Id = id}));
        }

        [HttpGet]
        [Route("{id:int}/attachments")]
        public async Task<ActionResult<Response<IEnumerable<InspectionAttachmentDto>>>> ListAttachments(
            [FromRoute] int id)
        {
            return Ok(await Mediator.Send(new ListInspectionAttachmentsQuery() {InspectionId = id}));
        }

        [HttpPost]
        [Route("{id:int}/attachments")]
        public async Task<ActionResult<Response<IEnumerable<InspectionAttachmentDto>>>> AddAttachments(
            [FromRoute] int id)
        {
            var formCollection = await Request.ReadFormAsync();
            var files = formCollection.Files;

            var request = new SaveInspectionAttachmentsRequest()
            {
                InspectionId = id,
                Attachments = await files.GetAttachmentsAsync()
            };

            return Ok(await Mediator.Send(request));
        }
    }
}