using API.Controllers.Base;
using API.Helpers;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.CreateRecommendation;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.UpdateRecommendation;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.ApproveRecommendation;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.DisapproveRecommendation;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetById;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.Search;
using Application.Wrappers;
using DTO.Files;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.SearchSideForm;

namespace API.Controllers.Settings.Checklist.RecommendationsCore.Recommendations
{
    [Route("recommendations-core/[controller]")]
    [ApiController]
    public class RecommendationsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<RecommendationFormDTO>>>> Search(
            [FromQuery] SearchQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("side-form")]
        public async Task<ActionResult<PagedResponse<IEnumerable<RecommendationFormDTO>>>> Search(
            [FromQuery] SearchSideFormQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<RecommendationDTO>>> GetById([FromQuery] GetByIdQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:int}/to-form")]
        public async Task<ActionResult<Response<RecommendationFormDTO>>> GetByIdToForm([FromQuery] GetByIdToFormQuery query, int id)
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Response<RecommendationDTO>>> Create()
        {
            IFormCollection? formCollection = await Request.ReadFormAsync();
            IFormFileCollection files = formCollection.Files;

            CreateRecommendationRequest request = JsonConvert.DeserializeObject<CreateRecommendationRequest>(formCollection["model"][0]);
            request.Version.Attachments = await files.GetAttachmentsAsync();

            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<RecommendationDTO>>> Update()
        {
            IFormCollection? formCollection = await Request.ReadFormAsync();
            IFormFileCollection files = formCollection.Files;

            //Se vier algum file, criar nova versão
            //Crio version nova e linko RecommendationAttachments com o novo Version

            UpdateRecommendationRequest request = JsonConvert.DeserializeObject<UpdateRecommendationRequest>(formCollection["model"][0]);
            request.Version.Attachments = await files.GetAttachmentsAsync();

            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [Route("{id:int}/approve")]
        public async Task<ActionResult<Response<RecommendationDTO>>> Approve(
            [FromQuery] ApproveRecommendationRequest query, int id
            )
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }

        [HttpPut]
        [Route("{id:int}/disapprove")]
        public async Task<ActionResult<Response<RecommendationDTO>>> Disapprove(
            [FromQuery] DisapproveRecommendationRequest query, int id
            )
        {
            query.Id = id;

            return Ok(await Mediator.Send(query));
        }
    }
}
