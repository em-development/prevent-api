using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<QuestionDTO>>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            IQuestionRepository questionRepository,
            IMapper mapper
            )
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<QuestionDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Question> questions = _questionRepository.SearchToDashboard(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await questions.Paginate<Question, QuestionDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
