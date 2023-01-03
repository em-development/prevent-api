using Application.Wrappers;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.SearchSideForm
{
    public class SearchSideFormQuery : FilterParams, IRequest<PagedResponse<IEnumerable<RecommendationFormDTO>>>
    {
        public string? Filter { get; set; }
        public int Status { get; set; }
    }
}