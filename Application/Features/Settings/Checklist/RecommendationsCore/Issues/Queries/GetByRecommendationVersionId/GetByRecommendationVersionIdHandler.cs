using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByAnswerVersionId;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByRecommendationVersionId
{
    internal class GetByRecommendationVersionIdHandler : IRequestHandler<GetByRecommendationVersionIdQuery, Response<IEnumerable<IssueDTO>>>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public GetByRecommendationVersionIdHandler(
            IIssueRepository issueRepository,
            IMapper mapper
            )
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<IssueDTO>>> Handle(
            GetByRecommendationVersionIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<Issue>? issues = await _issueRepository.GetByRecommendationVersionId(query.Id);

            IEnumerable<IssueDTO>? issuesDTO = _mapper.Map<IEnumerable<Issue>, IEnumerable<IssueDTO>>(issues);

            return new(issuesDTO);
        }
    }
}
