using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetById;

internal class GetByIdToFormHandler : IRequestHandler<GetByIdToFormQuery, Response<RecommendationFormDTO>>
{
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IMapper _mapper;

    public GetByIdToFormHandler(
        IRecommendationRepository recommendationRepository,
        IMapper mapper
        )
    {
        _recommendationRepository = recommendationRepository;
        _mapper = mapper;
    }

    public async Task<Response<RecommendationFormDTO>> Handle(
        GetByIdToFormQuery query,
        CancellationToken cancellationToken)
    {
        Recommendation? recommendation = await _recommendationRepository.GetByIdWithVersions(query.Id);

        RecommendationFormDTO? answerFormDTO = _mapper.Map<RecommendationFormDTO>(recommendation);

        return new(answerFormDTO);
    }
}
