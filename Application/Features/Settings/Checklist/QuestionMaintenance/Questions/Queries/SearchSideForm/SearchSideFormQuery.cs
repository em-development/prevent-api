using Application.Wrappers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.SearchSideForm
{
    public class SearchSideFormQuery : FilterParams, IRequest<PagedResponse<IEnumerable<QuestionFormDTO>>>
    {
        public string? Filter { get; set; }
    }
}