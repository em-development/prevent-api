using API.Controllers.Base;
using Application.Features.Settings.Checklist.RecommendationsCore.RecommendationVersions.Queries.GetByRecommendationId;
using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Checklist.RecommendationsCore.Recommendations
{
    [Route("recommendations-core/recommendations-versions")]
    [ApiController]
    public class RecommendationsVersionsController : BaseController
    {
        [HttpGet]
        [Route("get-by-recommendation-id/{id:int}")]
        public async Task<ActionResult<Response<IEnumerable<RecommendationVersionDTO>>>> GetByRecommendationId([FromQuery] GetByRecommendationIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
    }
}
