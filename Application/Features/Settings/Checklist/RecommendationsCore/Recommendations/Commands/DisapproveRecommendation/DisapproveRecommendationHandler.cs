using Adapters.Context;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Adapters.Services.BaseLogs;
using Application.Exceptions.Common;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.ApproveRecommendation;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.DisapproveRecommendation
{
    internal class DisapproveRecommendationHandler : IRequestHandler<DisapproveRecommendationRequest, Response<RecommendationFormDTO>>
    {
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IRecommendationVersionRepository _recommendationVersionRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public DisapproveRecommendationHandler(
            IRecommendationRepository recommendationRepository,
            IRecommendationVersionRepository recommendationVersionRepository,
            ILogService logService,
            IMapper mapper
            )
        {
            _recommendationRepository = recommendationRepository;
            _recommendationVersionRepository = recommendationVersionRepository;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<Response<RecommendationFormDTO>> Handle(
            DisapproveRecommendationRequest request,
            CancellationToken cancellationToken)
        {
            Recommendation? recommendation = await _recommendationRepository.GetByIdWithVersions(request.Id);

            if (recommendation == null)
            {
                throw new NotFoundException("api-entity-recommendation",
                    ("api-entity-recommendation-field-id", request.Id)
                );
            }

            await _recommendationVersionRepository.Disapprove(recommendation.Version);

            await _logService.DISAPPROVES_SETTINGS_RECOMMENDATION(recommendation);

            recommendation = await _recommendationRepository.GetByIdWithVersions(request.Id);

            return new Response<RecommendationFormDTO>(_mapper.Map<RecommendationFormDTO>(recommendation));
        }
    }
}
