using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetById
{
    internal class GetByHandler : IRequestHandler<GetByIdQuery, Response<IssueDTO>>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public GetByHandler(
            IIssueRepository issueRepository,
            IMapper mapper
            )
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        public async Task<Response<IssueDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            Issue? issues = await _issueRepository.GetByIdWithTags(query.Id);

            IssueDTO? issueDTO = _mapper.Map<IssueDTO>(issues);

            return new(issueDTO);
        }
    }
}
