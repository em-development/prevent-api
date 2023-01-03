using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Commands.UpdateIssue;

public class UpdateIssueRequest : IssueDTO, IRequest<Response<IssueDTO>>
{
}
