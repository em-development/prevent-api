using Application.Wrappers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.QuestionVersions.Queries.GetByQuestionId
{
    public class GetByQuestionIdQuery : IRequest<Response<IEnumerable<QuestionVersionDTO>>>
    {
        public int Id { get; set; }
    }
}