using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;
using DomainChecklistMaintenance = Domain.Entities.Settings.Checklist.ChecklistMaintenance;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.
    GetByInspectionTemplateVersionId
{
    internal class GetByInspectionTemplateVersionIdHandler : IRequestHandler<GetByInspectionTemplateVersionIdQuery,
        Response<IEnumerable<ChecklistDTO>>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public GetByInspectionTemplateVersionIdHandler(
            IChecklistRepository checklistRepository,
            IMapper mapper
        )
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ChecklistDTO>>> Handle(
            GetByInspectionTemplateVersionIdQuery query,
            CancellationToken cancellationToken)
        {
            var checklist = await _checklistRepository.GetByInspectionTemplateVersionId(query.Id);

            IEnumerable<ChecklistDTO>? checklistDto = _mapper.Map<IEnumerable<ChecklistFormDTO>>(checklist);

            return new Response<IEnumerable<ChecklistDTO>>(checklistDto);
        }
    }
}