using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.CreateRecommendation
{
    public class CreateRecommendationRequest : RecommendationFormDTO, IRequest<Response<RecommendationFormDTO>>
    {
    }
}
