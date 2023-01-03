using Application.Wrappers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.AnswerVersions.Queries.GetById
{
    public class GetByAnswerIdQuery : IRequest<Response<IEnumerable<AnswerVersionDTO>>>
    {
        public int Id { get; set; }
    }
}