using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.SearchSideForm
{
    internal class SearchSideFormHandler : IRequestHandler<SearchSideFormQuery, PagedResponse<IEnumerable<RecommendationFormDTO>>>
    {
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IMapper _mapper;

        public SearchSideFormHandler(
            IRecommendationRepository recommendationRepository,
            IMapper mapper
            )
        {
            _recommendationRepository = recommendationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RecommendationFormDTO>>> Handle(
            SearchSideFormQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Recommendation> answers = _recommendationRepository.SearchToSideForm(
                status: query.Status,
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await answers.Paginate<Recommendation, RecommendationFormDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
