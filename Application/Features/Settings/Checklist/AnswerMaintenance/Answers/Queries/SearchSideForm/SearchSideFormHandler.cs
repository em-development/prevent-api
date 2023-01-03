using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using MediatR;

namespace Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Queries.SearchSideForm
{
    internal class SearchSideFormHandler : IRequestHandler<SearchSideFormQuery, PagedResponse<IEnumerable<AnswerFormDTO>>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public SearchSideFormHandler(
            IAnswerRepository answerRepository,
            IMapper mapper
            )
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AnswerFormDTO>>> Handle(
            SearchSideFormQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<Answer> answers = _answerRepository.SearchToSideForm(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await answers.Paginate<Answer, AnswerFormDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
