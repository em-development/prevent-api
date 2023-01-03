using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Queries.GetById
{
    internal class GetByIdHandler : IRequestHandler<GetByIdQuery, Response<ChecklistFormDTO>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public GetByIdHandler(
            IChecklistRepository checklistRepository,
            IMapper mapper
            )
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<Response<ChecklistFormDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist? checklist = await _checklistRepository.GetByIdWithVersions(query.Id);

            ChecklistFormDTO? checklistDTO = _mapper.Map<ChecklistFormDTO>(checklist);

            return new(checklistDTO);
        }
    }
}
