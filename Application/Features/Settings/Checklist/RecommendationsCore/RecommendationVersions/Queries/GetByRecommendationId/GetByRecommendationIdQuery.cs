using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.RecommendationVersions.Queries.GetByRecommendationId
{
    public class GetByRecommendationIdQuery : IRequest<Response<IEnumerable<RecommendationVersionDTO>>>
    {
        public int Id { get; set; }
    }
}