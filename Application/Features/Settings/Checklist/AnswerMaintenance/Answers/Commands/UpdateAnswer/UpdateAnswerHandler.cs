using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerHandler : IRequestHandler<UpdateAnswerRequest, Response<AnswerFormDTO>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerVersionRepository _answerVersionRepository;
        private readonly IAnswerVersionIssuesRepository _answerVersionIssuesRepository;
        private readonly IMapper _mapper;

        public UpdateAnswerHandler(
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
            UpdateAnswerRequest request,
            CancellationToken cancellationToken)
        {
            Answer? answer = await _answerRepository.GetByIdAsync(request.Id);

            if (answer == null)
            {
                throw new NotFoundException("api-entity-answer",
                    ("api-entity-answer-field-id", request.Id)
                );
            }

            // Criar AnswerVersion com novo Description
            AnswerVersion answerVersion = new AnswerVersion(answer.Id, request.Description, 0);
            answerVersion.IncrementVersion(answer.Version?.Version ?? 0);
            answerVersion.SetDescription(request.AnswerVersion.Description);
            answerVersion = await _answerVersionRepository.InsertAsync(answerVersion);

            answer.SetVersion(answerVersion);
            answer.SetIsActive(request.IsActive);

            await _answerRepository.UpdateAsync(answer);

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

            answer = await _answerRepository.GetByIdWithVersions(answer.Id);

            return new Response<AnswerFormDTO>(_mapper.Map<AnswerFormDTO>(answer));
        }
    }
}
