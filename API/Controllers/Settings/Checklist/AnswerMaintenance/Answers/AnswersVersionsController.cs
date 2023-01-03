using API.Controllers.Base;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.AnswerVersions.Queries.GetById;
using Application.Wrappers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Checklist.AnswerMaintenance.Answers
{
    [Route("answer/versions")]
    [ApiController]
    public class AnswersVersionsController : BaseController
    {
        [HttpGet]
        [Route("get-by-answer-id/{id:int}")]
        public async Task<ActionResult<Response<IEnumerable<AnswerVersionDTO>>>> GetByAnswerId([FromQuery] GetByAnswerIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
    }
}
