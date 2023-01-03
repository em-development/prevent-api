using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.DisapproveRecommendation
{
    public class DisapproveRecommendationRequest : IRequest<Response<RecommendationFormDTO>>
    {
        public int Id { get; set; }
    }
}
