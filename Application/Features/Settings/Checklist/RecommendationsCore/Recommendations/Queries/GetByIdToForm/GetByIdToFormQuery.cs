using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetById;

public class GetByIdToFormQuery : IRequest<Response<RecommendationFormDTO>>
{
    public int Id { get; set; }
}
