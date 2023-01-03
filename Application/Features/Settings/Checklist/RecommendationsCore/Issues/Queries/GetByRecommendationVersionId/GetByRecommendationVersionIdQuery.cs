using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByRecommendationVersionId
{
    public class GetByRecommendationVersionIdQuery : IRequest<Response<IEnumerable<IssueDTO>>>
    {
        public int Id { get; set; }
    }
}