using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Commands.CreateIssue
{
    public class CreateIssueRequest : IssueDTO, IRequest<Response<IssueDTO>>
    {
    }
}
