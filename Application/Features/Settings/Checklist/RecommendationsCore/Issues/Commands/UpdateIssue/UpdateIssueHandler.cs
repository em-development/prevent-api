using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Adapters.Services.BaseLogs;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Commands.UpdateIssue
{
    public class UpdateIssueHandler : IRequestHandler<UpdateIssueRequest, Response<IssueDTO>>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IIssueTagRepository _issueTagRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public UpdateIssueHandler(
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
            UpdateIssueRequest request,
            CancellationToken cancellationToken)
        {
            Issue? issue = await _issueRepository.GetByIdWithTags(request.Id);

            if (issue == null)
            {
                throw new NotFoundException("api-entity-issue",
                    ("api-entity-issue-field-id", request.Id)
                );
            }

            issue.Update(request.Description, request.IsActive);

            await _issueRepository.UpdateAsync(issue);

            await _logService.UPDATES_SETTINGS_ISSUE(issue);

            List<IssueTag> toDelete = new();

            foreach (string? tag in request.Tags)
            {
                IssueTag? currentTag = issue.Tags?.FirstOrDefault(t => t.Tag.Value == tag);

                if (currentTag == null)
                {
                    IssueTag newTag = await _issueTagRepository.InsertAsync(new IssueTag(issue.Id, tag));
                    await _logService.CREATES_SETTINGS_ISSUE_TAGS(newTag);
                }
            }

            if (issue.Tags != null)
            {
                foreach (IssueTag tag in issue.Tags)
                {
                    string? currentTag = request.Tags?.FirstOrDefault(t => t == tag.Tag.Value);

                    if (currentTag == null)
                    {
                        await _issueTagRepository.RemoveAsync(tag);
                        await _logService.DELETES_SETTINGS_ISSUE_TAGS(tag);
                    }
                }
            }

            issue = await _issueRepository.GetByIdWithTags(issue.Id);

            return new Response<IssueDTO>(_mapper.Map<IssueDTO>(issue));
        }
    }
}
