using API.Controllers.Base;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Commands.CreateChecklist;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Commands.UpdateChecklist;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.GetById;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.GetByInspectionTemplateVersionId;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.
    GetByInspectionTemplateVersionIdToAnswer;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.Search;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.SearchSideForm;
using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Checklist.ChecklistMaintenance
{
    [Route("checklist-maintenance/[controller]")]
    [ApiController]
    public class ChecklistController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<ChecklistDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("side-form")]
        public async Task<ActionResult<PagedResponse<IEnumerable<ChecklistFormDTO>>>> Search(
            [FromQuery] SearchSideFormQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<ChecklistDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}/to-form")]
        public async Task<ActionResult<Response<ChecklistFormDTO>>> GetByIdToForm([FromQuery] GetByIdToFormQuery query,
            int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("get-by-inspection-template-version-id/{id:int}")]
        public async Task<ActionResult<Response<ChecklistDTO>>> GetByInspectionTemplateVersionId(int id)
        {
            return Ok(await Mediator.Send(new GetByInspectionTemplateVersionIdQuery() {Id = id}));
        }

        [HttpGet]
        [Route("get-by-inspection-template-version-id/{id:int}/{inspectionId:int}")]
        public async Task<ActionResult<Response<ChecklistDTO>>> GetByInspectionTemplateVersionId(int id,
            int inspectionId)
        {
            return Ok(await Mediator.Send(new GetByInspectionTemplateVersionIdToAnswerQuery()
                {Id = id, InspectionId = inspectionId}));
        }

        [HttpPost]
        public async Task<ActionResult<Response<ChecklistDTO>>> Create(
            [FromBody] CreateChecklistRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<ChecklistDTO>>> Update(
            [FromBody] UpdateChecklistRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }
    }
}