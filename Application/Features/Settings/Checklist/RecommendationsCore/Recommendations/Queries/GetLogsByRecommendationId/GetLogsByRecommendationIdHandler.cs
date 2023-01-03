using Adapters.Repositories.BaseLogs;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.BaseLogs;
using DTO.BaseLogs;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetLogsByRecommendationId
{
    internal class GetLogsByRecommendationIdHandler : IRequestHandler<GetLogsByRecommendationIdQuery, Response<IEnumerable<LogDTO>?>>
    {
        private readonly ILogRepository _logRepository;  
        private readonly IMapper _mapper;

        public GetLogsByRecommendationIdHandler(
            ILogRepository logRepository,
            IMapper mapper
            )
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<LogDTO>?>> Handle(
            GetLogsByRecommendationIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<Log>? logs = await _logRepository.GetByRecommendationId(query.Id);

            IEnumerable<LogDTO>? result = _mapper.Map<IEnumerable<Log>, IEnumerable<LogDTO>>(logs);

            return new(result);
        }
    }
}
