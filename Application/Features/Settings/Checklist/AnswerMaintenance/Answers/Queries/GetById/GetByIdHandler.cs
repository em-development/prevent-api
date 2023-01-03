using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.GetById
{
    internal class GetByIdHandler : IRequestHandler<GetByIdQuery, Response<AnswerFormDTO>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public GetByIdHandler(
            IAnswerRepository answerRepository,
            IMapper mapper
            )
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<Response<AnswerFormDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            Answer? answers = await _answerRepository.GetByIdWithVersions(query.Id);

            AnswerFormDTO? answerDTO = _mapper.Map<AnswerFormDTO>(answers);

            return new(answerDTO);
        }
    }
}
