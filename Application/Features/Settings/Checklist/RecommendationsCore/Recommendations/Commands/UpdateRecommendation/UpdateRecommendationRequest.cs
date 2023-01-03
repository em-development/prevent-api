using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.UpdateRecommendation
{

    public class UpdateRecommendationRequest : RecommendationFormDTO, IRequest<Response<RecommendationFormDTO>>
    {
    }
}
