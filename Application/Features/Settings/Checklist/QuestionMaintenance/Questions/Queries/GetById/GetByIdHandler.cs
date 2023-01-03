using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.GetById
{
    internal class GetByIdHandler : IRequestHandler<GetByIdQuery, Response<QuestionFormDTO>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetByIdHandler(
            IQuestionRepository questionRepository,
            IMapper mapper
            )
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<QuestionFormDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            Question? questions = await _questionRepository.GetByIdWithVersions(query.Id);

            QuestionFormDTO? questionDTO = _mapper.Map<QuestionFormDTO>(questions);

            return new(questionDTO);
        }
    }
}
