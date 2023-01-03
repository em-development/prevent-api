using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.QuestionVersions.Queries.GetByQuestionId
{
    internal class GetByQuestionIdHandler : IRequestHandler<GetByQuestionIdQuery, Response<IEnumerable<QuestionVersionDTO>>>
    {
        private readonly IQuestionVersionRepository _questionVersionRepository;
        private readonly IMapper _mapper;

        public GetByQuestionIdHandler(
            IQuestionVersionRepository questionVersionRepository,
            IMapper mapper
            )
        {
            _questionVersionRepository = questionVersionRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<QuestionVersionDTO>>> Handle(
            GetByQuestionIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<QuestionVersion>? questionVersions = await _questionVersionRepository.GetByQuestionId(query.Id);

            IEnumerable<QuestionVersionDTO>? result = _mapper.Map<IEnumerable<QuestionVersion>, IEnumerable<QuestionVersionDTO>>(questionVersions);

            return new(result);
        }

    }
}
