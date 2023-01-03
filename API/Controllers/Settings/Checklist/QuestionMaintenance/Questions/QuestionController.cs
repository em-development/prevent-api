using API.Controllers.Base;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Commands.CreateQuestion;
using Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Commands.UpdateQuestion;
using Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.GetById;
using Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.Search;
using Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.SearchSideForm;
using Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.GetByChecklistVersionId;

namespace API.Controllers.Settings.Checklist.RecommendationsCore.Recommendations
{
    [Route("question-maintenance/[controller]")]
    [ApiController]
    public class QuestionController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<QuestionDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<QuestionDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("side-form")]
        public async Task<ActionResult<PagedResponse<IEnumerable<QuestionFormDTO>>>> Search(
            [FromQuery] SearchSideFormQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}/to-form")]
        public async Task<ActionResult<Response<QuestionFormDTO>>> GetByIdToForm([FromQuery] GetByIdToFormQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("get-by-checklist-version-id/{id}")]
        public async Task<ActionResult<Response<QuestionDTO>>> GetByChecklistVersionId([FromQuery] GetByChecklistVersionIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<QuestionDTO>>> Create(
            [FromBody] CreateQuestionRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<QuestionDTO>>> Update(
            [FromBody] UpdateQuestionRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }

    }
}
