using Application.Wrappers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<AnswerFormDTO>>
    {
        public int Id { get; set; }
    }
}