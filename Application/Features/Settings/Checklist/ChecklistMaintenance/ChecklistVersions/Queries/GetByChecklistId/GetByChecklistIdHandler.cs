using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.ChecklistVersions.Queries.GetByChecklistId
{
    internal class GetByChecklistIdHandler : IRequestHandler<GetByChecklistIdQuery, Response<IEnumerable<ChecklistVersionDTO>>>
    {
        private readonly IChecklistVersionRepository _checklistVersionRepository;
        private readonly IMapper _mapper;

        public GetByChecklistIdHandler(
            IChecklistVersionRepository checklistVersionRepository,
            IMapper mapper
            )
        {
            _checklistVersionRepository = checklistVersionRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ChecklistVersionDTO>>> Handle(
            GetByChecklistIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<ChecklistVersion>? checklistVersions = await _checklistVersionRepository.GetByChecklistId(query.Id);

            IEnumerable<ChecklistVersionDTO>? result = _mapper.Map<IEnumerable<ChecklistVersion>, IEnumerable<ChecklistVersionDTO>>(checklistVersions);

            return new(result);
        }

    }
}
