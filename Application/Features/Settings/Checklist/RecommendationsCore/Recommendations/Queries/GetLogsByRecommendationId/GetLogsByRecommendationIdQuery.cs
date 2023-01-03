using Application.Wrappers;
using DTO.BaseLogs;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetLogsByRecommendationId
{
    public class GetLogsByRecommendationIdQuery : IRequest<Response<IEnumerable<LogDTO>?>>
    {
        public int Id { get; set; }
    }
}