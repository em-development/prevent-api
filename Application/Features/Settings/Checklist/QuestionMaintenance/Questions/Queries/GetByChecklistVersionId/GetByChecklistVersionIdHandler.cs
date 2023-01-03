using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Issues;
using Application.Features.Settings.Checklist.RecommendationsCore.Issues.Queries.GetByAnswerVersionId;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.GetByChecklistVersionId
{
    internal class GetByChecklistVersionIdHandler : IRequestHandler<GetByChecklistVersionIdQuery, Response<IEnumerable<QuestionDTO>>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetByChecklistVersionIdHandler(
            IQuestionRepository questionRepository,
            IMapper mapper
            )
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<QuestionDTO>>> Handle(
            GetByChecklistVersionIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<Question>? issues = await _questionRepository.GetByChecklistVersionId(query.Id);

            IEnumerable<QuestionDTO>? issuesDTO = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionFormDTO>>(issues);

            return new(issuesDTO);
        }
    }
}
