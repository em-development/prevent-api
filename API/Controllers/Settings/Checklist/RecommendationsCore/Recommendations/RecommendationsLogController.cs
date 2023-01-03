using API.Controllers.Base;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using DTO.BaseLogs;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetLogsByRecommendationId;

namespace API.Controllers.Settings.Checklist.RecommendationsCore.Recommendations
{
    [Route("recommendations-core/log")]
    [ApiController]
    public class RecommendationsLogController : BaseController
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<LogDTO>>> GetById([FromQuery] GetLogsByRecommendationIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

    }
}
