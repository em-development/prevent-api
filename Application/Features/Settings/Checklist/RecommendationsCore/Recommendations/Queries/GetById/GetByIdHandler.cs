using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetById
{
    internal class GetByHandler : IRequestHandler<GetByIdQuery, Response<RecommendationFormDTO>>
    {
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IMapper _mapper;

        public GetByHandler(
            IRecommendationRepository recommendationRepository,
            IMapper mapper
            )
        {
            _recommendationRepository = recommendationRepository;
            _mapper = mapper;
        }

        public async Task<Response<RecommendationFormDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            Recommendation? recommendations = await _recommendationRepository.GetByIdWithVersions(query.Id);

            RecommendationFormDTO? recommendationDTO = _mapper.Map<RecommendationFormDTO>(recommendations);

            return new(recommendationDTO);
        }
    }
}
