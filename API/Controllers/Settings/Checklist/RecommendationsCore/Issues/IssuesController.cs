using API.Controllers.Base;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Commands.CreateIssue;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Commands.UpdateIssue;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetById;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByAnswerVersionId;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.Search;
using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByRecommendationVersionId;

namespace API.Controllers.Settings.Checklist.RecommendationsCore.Issues
{
    [Route("recommendations/[controller]")]
    [ApiController]
    public class IssuesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<IssueDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response<IssueDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("get-by-answer-version-id/{id}")]
        public async Task<ActionResult<Response<IssueDTO>>> GetByAnswerVersionId([FromQuery] GetByAnswerVersionIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("get-by-recommendation-version-id/{id}")]
        public async Task<ActionResult<Response<IssueDTO>>> GetByRecommendationVersionId([FromQuery] GetByRecommendationVersionIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<IssueDTO>>> Crate(
            [FromBody] CreateIssueRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Response<IssueDTO>>> Update(
            [FromBody] UpdateIssueRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }
    }
}
