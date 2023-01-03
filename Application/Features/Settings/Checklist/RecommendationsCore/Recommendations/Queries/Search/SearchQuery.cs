using Application.Wrappers;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.Search
{
    public class SearchQuery : FilterParams, IRequest<PagedResponse<IEnumerable<RecommendationDTO>>>
    {
        public string? Filter { get; set; }
        public int Status { get; set; }
    }
}