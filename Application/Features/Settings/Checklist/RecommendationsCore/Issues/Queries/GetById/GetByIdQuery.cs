using Application.Wrappers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<IssueDTO>>
    {
        public int Id { get; set; }
    }
}