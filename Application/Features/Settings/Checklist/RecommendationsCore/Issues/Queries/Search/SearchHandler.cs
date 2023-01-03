using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<IssueDTO>>>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            IIssueRepository issueRepository,
            IMapper mapper
            )
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<IssueDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            var issues = _issueRepository.SearchToDashboard(
                filter: query.Filter,
                tag: query.Tag,
                current: query.Current,
                limit: query.Limit,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await issues.Paginate<Issue, IssueDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
