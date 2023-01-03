using Application.Wrappers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.GetByChecklistVersionId
{
    public class GetByChecklistVersionIdQuery : IRequest<Response<IEnumerable<QuestionDTO>>>
    {
        public int Id { get; set; }
    }
}