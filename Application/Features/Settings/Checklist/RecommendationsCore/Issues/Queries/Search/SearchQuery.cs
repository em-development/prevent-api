using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.Search
{
    public class SearchQuery : FilterParams, IRequest<PagedResponse<IEnumerable<IssueDTO>>>
    {
        public string? Filter { get; set; }
        public string? Tag { get; set; }
    }
}