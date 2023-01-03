using API.Controllers.Base;
using Application.Features.Settings.Checklist.QuestionMaintenance.QuestionVersions.Queries.GetByQuestionId;
using Application.Wrappers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings.Checklist.QuestionMaintenance.Questions
{
    [Route("question/versions")]
    [ApiController]
    public class QuestionVersionsController : BaseController
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<IEnumerable<QuestionVersionDTO>>>> GetByQuestionId([FromQuery] GetByQuestionIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
    }
}
