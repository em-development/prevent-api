using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.RecommendationVersions.Queries.GetByRecommendationId
{
    internal class GetByRecommendationIdHandler : IRequestHandler<GetByRecommendationIdQuery, Response<IEnumerable<RecommendationVersionDTO>>>
    {
        private readonly IRecommendationVersionRepository _recommendationVersionRepository;
        private readonly IMapper _mapper;

        public GetByRecommendationIdHandler(
            IRecommendationVersionRepository recommendationVersionRepository,
            IMapper mapper
            )
        {
            _recommendationVersionRepository = recommendationVersionRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<RecommendationVersionDTO>>> Handle(
            GetByRecommendationIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<RecommendationVersion>? recommendationVersions = await _recommendationVersionRepository.GetByRecommendationId(query.Id);

            IEnumerable<RecommendationVersionDTO>? result = _mapper.Map<IEnumerable<RecommendationVersion>, IEnumerable<RecommendationVersionDTO>>(recommendationVersions);

            return new(result);
        }

    }
}
