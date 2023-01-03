using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.GetById;

internal class GetByIdToFormHandler : IRequestHandler<GetByIdToFormQuery, Response<QuestionFormDTO>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetByIdToFormHandler(
        IQuestionRepository questionRepository,
        IMapper mapper
        )
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<Response<QuestionFormDTO>> Handle(
        GetByIdToFormQuery query,
        CancellationToken cancellationToken)
    {
        Question? questions = await _questionRepository.GetByIdWithVersions(query.Id);

        QuestionFormDTO? questionFormDTO = _mapper.Map<QuestionFormDTO>(questions);

        return new(questionFormDTO);
    }
}
