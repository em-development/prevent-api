using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.GetById;

internal class GetByIdToFormHandler : IRequestHandler<GetByIdToFormQuery, Response<AnswerFormDTO>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetByIdToFormHandler(
        IAnswerRepository answerRepository,
        IMapper mapper
        )
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<Response<AnswerFormDTO>> Handle(
        GetByIdToFormQuery query,
        CancellationToken cancellationToken)
    {
        Answer? answers = await _answerRepository.GetByIdWithVersions(query.Id);

        AnswerFormDTO? answerFormDTO = _mapper.Map<AnswerFormDTO>(answers);

        return new(answerFormDTO);
    }
}
