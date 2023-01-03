using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByAnswerVersionId
{
    public class GetByAnswerVersionIdQuery : IRequest<Response<IEnumerable<IssueDTO>>>
    {
        public int Id { get; set; }
    }
}