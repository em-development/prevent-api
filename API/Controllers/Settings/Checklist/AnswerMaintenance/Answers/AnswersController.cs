using API.Controllers.Base;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.CreateAnswer;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.UpdateAnswer;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.GetById;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.Search;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.SearchSideForm;
using Application.Wrappers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Checklist.AnswerMaintenance.Answers
{
    [Route("answer-maintenance/[controller]")]
    [ApiController]
    public class AnswersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<AnswerDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("side-form")]
        public async Task<ActionResult<PagedResponse<IEnumerable<AnswerFormDTO>>>> Search(
            [FromQuery] SearchSideFormQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<AnswerDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}/to-form")]
        public async Task<ActionResult<Response<AnswerFormDTO>>> GetByIdToForm([FromQuery] GetByIdToFormQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<AnswerDTO>>> Create(
            [FromBody] CreateAnswerRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<AnswerDTO>>> Update(
            [FromBody] UpdateAnswerRequest request, int id)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request));
        }
    }
}
