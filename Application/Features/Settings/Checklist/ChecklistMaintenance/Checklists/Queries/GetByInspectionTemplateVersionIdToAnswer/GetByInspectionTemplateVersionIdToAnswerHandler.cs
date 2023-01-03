using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;
using DomainChecklistMaintenance = Domain.Entities.Settings.Checklist.ChecklistMaintenance;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.
    GetByInspectionTemplateVersionIdToAnswer
{
    internal class GetByInspectionTemplateVersionIdToAnswerHandler : IRequestHandler<
        GetByInspectionTemplateVersionIdToAnswerQuery,
        Response<IEnumerable<ChecklistDTO>>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public GetByInspectionTemplateVersionIdToAnswerHandler(
            IChecklistRepository checklistRepository,
            IMapper mapper
        )
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ChecklistDTO>>> Handle(
            GetByInspectionTemplateVersionIdToAnswerQuery query,
            CancellationToken cancellationToken)
        {
            var checklist =
                await _checklistRepository.GetByInspectionTemplateVersionIdToAnswer(query.Id, query.InspectionId);

            IEnumerable<ChecklistDTO>? checklistDto = _mapper.Map<IEnumerable<ChecklistFormDTO>>(checklist);

            return new Response<IEnumerable<ChecklistDTO>>(checklistDto);
        }
    }
}