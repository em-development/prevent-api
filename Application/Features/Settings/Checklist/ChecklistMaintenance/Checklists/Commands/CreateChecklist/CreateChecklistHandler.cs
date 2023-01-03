using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Commands.CreateChecklist
{
    internal class CreateChecklistHandler : IRequestHandler<CreateChecklistRequest, Response<ChecklistFormDTO>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IChecklistVersionRepository _checklistVersionRepository;
        private readonly IChecklistVersionQuestionsRepository _checklistVersionQuestionsRepository;
        private readonly IMapper _mapper;

        public CreateChecklistHandler(
            IChecklistRepository checklistRepository,
            IChecklistVersionRepository checklistVersionRepository,
            IChecklistVersionQuestionsRepository checklistVersionQuestionsRepository,
            IMapper mapper
            )
        {
            _checklistRepository = checklistRepository;
            _checklistVersionRepository = checklistVersionRepository;
            _checklistVersionQuestionsRepository = checklistVersionQuestionsRepository;
            _mapper = mapper;
        }

        public async Task<Response<ChecklistFormDTO>> Handle(
            CreateChecklistRequest request,
            CancellationToken cancellationToken)
        {
            Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist checklist = new Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist(request.IsActive);
            checklist = await _checklistRepository.InsertAsync(checklist);

            ChecklistVersion checklistVersion = new ChecklistVersion(checklist.Id, request.Title, request.Key, 0);
            checklistVersion = await _checklistVersionRepository.InsertAsync(checklistVersion);

            checklist.SetVersion(checklistVersion.Id);
            checklist = await _checklistRepository.UpdateAsync(checklist);

            if (request.Version != null)
            {
                if (request.Version.Questions != null)
                {
                    foreach (int? questionId in request.Version.Questions.Select(x => x.QuestionId))
                    {
                        await _checklistVersionQuestionsRepository.InsertAsync(new ChecklistVersionQuestions(checklistVersion.Id, questionId.Value));
                    }
                }
            }

            checklist = await _checklistRepository.GetByIdWithVersions(checklist.Id) ?? checklist;

            return new Response<ChecklistFormDTO>(_mapper.Map<ChecklistFormDTO>(checklist));
        }
    }
}
