using Application.Wrappers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.SearchSideForm
{
    public class SearchSideFormQuery : FilterParams, IRequest<PagedResponse<IEnumerable<AnswerFormDTO>>>
    {
        public string? Filter { get; set; }
    }
}