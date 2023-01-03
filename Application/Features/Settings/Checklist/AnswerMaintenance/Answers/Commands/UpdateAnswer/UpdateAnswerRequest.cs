using Application.Wrappers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.UpdateAnswer;

public class UpdateAnswerRequest : AnswerFormDTO, IRequest<Response<AnswerFormDTO>>
{
}
