using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<RecommendationDTO>>>
    {
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            IRecommendationRepository recommendationRepository,
            IMapper mapper
            )
        {
            _recommendationRepository = recommendationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RecommendationDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Recommendation> answers = _recommendationRepository.SearchToDashboard(
                status: query.Status,
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await answers.Paginate<Recommendation, RecommendationDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
