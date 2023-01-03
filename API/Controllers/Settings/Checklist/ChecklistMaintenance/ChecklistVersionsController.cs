using API.Controllers.Base;
using Application.Features.Settings.Checklist.ChecklistMaintenance.ChecklistVersions.Queries.GetByChecklistId;
using Application.Wrappers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Checklist.AnswerMaintenance.Answers
{
    [Route("checklist/versions")]
    [ApiController]
    public class ChecklistVersionsController : BaseController
    {
        [HttpGet]
        [Route("get-by-checklist-id/{id:int}")]
        public async Task<ActionResult<Response<IEnumerable<ChecklistVersionDTO>>>> GetByChecklistId([FromQuery] GetByChecklistIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
    }
}
