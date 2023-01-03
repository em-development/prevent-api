using API.Controllers.Base;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using DTO.BaseLogs;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetLogsByInspectionId;

namespace API.Controllers.Settings.Inspections.InspectionMaintenance.Inspections
{
    [Route("inspection-core/log")]
    [ApiController]
    public class InspectionLogController : BaseController
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<LogDTO>>> GetById([FromQuery] GetLogsByInspectionIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

    }
}
