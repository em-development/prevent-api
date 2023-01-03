using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.GetById;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.GetByIdToForm
{
    internal class GetByIdToFormHandler : IRequestHandler<GetByIdToFormQuery, Response<ChecklistFormDTO>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public GetByIdToFormHandler(
            IChecklistRepository checklistRepository,
            IMapper mapper
            )
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<Response<ChecklistFormDTO>> Handle(
            GetByIdToFormQuery query,
            CancellationToken cancellationToken)
        {
            Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist? checklist = await _checklistRepository.GetByIdWithVersions(query.Id);

            ChecklistFormDTO? checklistFormDTO = _mapper.Map<ChecklistFormDTO>(checklist);

            return new(checklistFormDTO);
        }
    }

}
