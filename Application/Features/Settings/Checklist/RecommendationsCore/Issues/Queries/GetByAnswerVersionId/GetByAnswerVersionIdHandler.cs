using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByAnswerVersionId
{
    internal class GetByAnswerVersionIdHandler : IRequestHandler<GetByAnswerVersionIdQuery, Response<IEnumerable<IssueDTO>>>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public GetByAnswerVersionIdHandler(
            IIssueRepository issueRepository,
            IMapper mapper
            )
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<IssueDTO>>> Handle(
            GetByAnswerVersionIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<Issue>? issues = await _issueRepository.GetByAnswerVersionId(query.Id);

            IEnumerable<IssueDTO>? issuesDTO = _mapper.Map<IEnumerable<Issue>, IEnumerable<IssueDTO>>(issues);

            return new(issuesDTO);
        }
    }
}
