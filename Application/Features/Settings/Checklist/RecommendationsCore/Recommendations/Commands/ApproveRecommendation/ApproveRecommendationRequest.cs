using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.ApproveRecommendation
{
    public class ApproveRecommendationRequest : IRequest<Response<RecommendationFormDTO>>
    {
        public int Id { get; set; }
    }
}
