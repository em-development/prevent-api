using Application.Wrappers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.CreateAnswer
{
    public class CreateAnswerRequest : AnswerFormDTO, IRequest<Response<AnswerFormDTO>>
    {
    }
}
