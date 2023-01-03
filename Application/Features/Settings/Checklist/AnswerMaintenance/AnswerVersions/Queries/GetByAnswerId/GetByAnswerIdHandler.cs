using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.AnswerVersions.Queries.GetById
{
    internal class GetByAnswerIdHandler : IRequestHandler<GetByAnswerIdQuery, Response<IEnumerable<AnswerVersionDTO>>>
    {
        private readonly IAnswerVersionRepository _answerVersionRepository;
        private readonly IMapper _mapper;

        public GetByAnswerIdHandler(
            IAnswerVersionRepository answerVersionRepository,
            IMapper mapper
            )
        {
            _answerVersionRepository = answerVersionRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<AnswerVersionDTO>>> Handle(
            GetByAnswerIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<AnswerVersion>? answerVersions = await _answerVersionRepository.GetByAnswerId(query.Id);

            IEnumerable<AnswerVersionDTO>? result = _mapper.Map<IEnumerable<AnswerVersion>, IEnumerable<AnswerVersionDTO>>(answerVersions);

            return new(result);
        }

    }
}
