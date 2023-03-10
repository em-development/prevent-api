using Application.Wrappers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<QuestionFormDTO>>
    {
        public int Id { get; set; }
    }
}