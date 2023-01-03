using Application.Wrappers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Commands.CreateQuestion
{
    public class CreateQuestionRequest : QuestionFormDTO, IRequest<Response<QuestionFormDTO>>
    {
    }
}
