using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Queries.SearchSideForm
{
    internal class SearchSideFormHandler : IRequestHandler<SearchSideFormQuery, PagedResponse<IEnumerable<QuestionFormDTO>>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public SearchSideFormHandler(
            IQuestionRepository questionRepository,
            IMapper mapper
            )
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<QuestionFormDTO>>> Handle(
            SearchSideFormQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Question> questions = _questionRepository.SearchToSideForm(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await questions.Paginate<Question, QuestionFormDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
