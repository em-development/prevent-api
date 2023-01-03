using API.Controllers.Base;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.CreateInspection;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.UpdateInspection;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.Search;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetByIdToForm;
using Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.ScheduleInspection;

namespace API.Controllers.Settings.Inspections.InspectionMaintenance.Inspections
{
    [Route("inspections/inspections-maintenance")]
    [ApiController]
    public class InspectionsMaintenanceController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<CompactInspectionDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<InspectionFormDTO>>> GetById([FromQuery] GetByIdToFormQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<InspectionDTO>>> Create(
            [FromBody] CreateInspectionRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<InspectionDTO>>> Update(
            [FromBody] UpdateInspectionRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }

        #region Inspection Schedule

        [HttpPut]
        [Route("schedule/{id:int}")]
        public async Task<ActionResult<Response<InspectionDTO>>> Schedule(
            [FromBody] ScheduleInspectionRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        } 

        #endregion
    }
}
