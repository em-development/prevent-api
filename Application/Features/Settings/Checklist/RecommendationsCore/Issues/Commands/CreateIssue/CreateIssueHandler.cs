using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Adapters.Services.BaseLogs;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Commands.CreateIssue
{
    internal class CreateIssueHandler : IRequestHandler<CreateIssueRequest, Response<IssueDTO>>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IIssueTagRepository _issueTagRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public CreateIssueHandler(
            IIssueRepository issueRepository,
            IIssueTagRepository issueTagRepository,
            ILogService logService,
            IMapper mapper
            )
        {
            _issueRepository = issueRepository;
            _issueTagRepository = issueTagRepository;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<Response<IssueDTO>> Handle(
            CreateIssueRequest request,
            CancellationToken cancellationToken)
        {
            Issue issue = new Issue(request.Description, request.IsActive);

            issue = await _issueRepository.InsertAsync(issue);

            foreach (string? tag in request.Tags)
            {
                IssueTag newTag = await _issueTagRepository.InsertAsync(new IssueTag(issue.Id, tag));
                await _logService.CREATES_SETTINGS_ISSUE_TAGS(newTag);
            }

            await _logService.CREATES_SETTINGS_ISSUE(issue);

            issue = await _issueRepository.GetByIdWithTags(issue.Id) ?? issue;

            return new Response<IssueDTO>(_mapper.Map<IssueDTO>(issue));
        }
    }
}
