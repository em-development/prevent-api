using Application.Wrappers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Commands.UpdateQuestion;

public class UpdateQuestionRequest : QuestionFormDTO, IRequest<Response<QuestionFormDTO>>
{
}
