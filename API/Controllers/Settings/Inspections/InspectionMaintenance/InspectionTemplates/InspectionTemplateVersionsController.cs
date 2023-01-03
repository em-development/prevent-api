using API.Controllers.Base;
using Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplateVersions.Queries.GetByInspectionTemplateId;
using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    [Route("inspection-template/versions")]
    [ApiController]
    public class InspectionTemplateVersionsController : BaseController
    {
        [HttpGet]
        [Route("get-by-inspection-template-id/{id:int}")]
        public async Task<ActionResult<Response<IEnumerable<InspectionTemplateVersionDTO>>>> GetByInspectionTemplateId([FromQuery] GetByInspectionTemplateIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
    }
}
