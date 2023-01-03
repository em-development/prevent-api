using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.CreateAnswer
{
    internal class CreateAnswerHandler : IRequestHandler<CreateAnswerRequest, Response<AnswerFormDTO>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerVersionRepository _answerVersionRepository;
        private readonly IAnswerVersionIssuesRepository _answerVersionIssuesRepository;
        private readonly IMapper _mapper;

        public CreateAnswerHandler(
            IAnswerRepository answerRepository,
            IAnswerVersionRepository answerVersionRepository,
            IAnswerVersionIssuesRepository answerVersionIssuesRepository,
            IMapper mapper
            )
        {
            _answerRepository = answerRepository;
            _answerVersionRepository = answerVersionRepository;
            _answerVersionIssuesRepository = answerVersionIssuesRepository;
            _mapper = mapper;
        }

        public async Task<Response<AnswerFormDTO>> Handle(
            CreateAnswerRequest request,
            CancellationToken cancellationToken)
        {
            Answer answer = new Answer(request.IsActive);
            answer = await _answerRepository.InsertAsync(answer);

            AnswerVersion answerVersion = new AnswerVersion(answer.Id, request.Description, 0);
            answerVersion = await _answerVersionRepository.InsertAsync(answerVersion);

            answer.SetVersion(answerVersion.Id);
            answer = await _answerRepository.UpdateAsync(answer);

            if (request.AnswerVersion != null) 
            {
                if (request.AnswerVersion.Issues != null)
                {
                    foreach (int? issue in request.AnswerVersion.Issues.Select(x => x.Id))
                    {
                        await _answerVersionIssuesRepository.InsertAsync(new AnswerVersionIssues(answerVersion.Id, issue.Value));
                    }
                }
            }

            answer = await _answerRepository.GetByIdWithVersions(answer.Id) ?? answer;

            return new Response<AnswerFormDTO>(_mapper.Map<AnswerFormDTO>(answer));
        }
    }
}
