using Adapters.Repositories.BaseLogs;
using Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Queries.GetLogsByRecommendationId;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.BaseLogs;
using DTO.BaseLogs;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetLogsByInspectionId
{
    internal class GetLogsByInspectionIdHandler : IRequestHandler<GetLogsByInspectionIdQuery, Response<IEnumerable<LogDTO>?>>
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public GetLogsByInspectionIdHandler(
            ILogRepository logRepository,
            IMapper mapper
            )
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<LogDTO>?>> Handle(
            GetLogsByInspectionIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<Log>? logs = await _logRepository.GetByInspectionId(query.Id);

            IEnumerable<LogDTO>? result = _mapper.Map<IEnumerable<Log>, IEnumerable<LogDTO>>(logs);

            return new(result);
        }
    }
}
