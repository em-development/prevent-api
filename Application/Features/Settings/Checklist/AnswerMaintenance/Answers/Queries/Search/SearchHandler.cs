using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<AnswerDTO>>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            IAnswerRepository answerRepository,
            IMapper mapper
            )
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AnswerDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Answer> answers = _answerRepository.SearchToDashboard(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await answers.Paginate<Answer, AnswerDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
