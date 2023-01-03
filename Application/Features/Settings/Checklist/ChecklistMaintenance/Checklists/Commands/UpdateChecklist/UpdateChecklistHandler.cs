using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Adapters.Repositories.Settings.Checklist.ChecklistMaintenance;
using Application.Exceptions.Common;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.UpdateAnswer;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.ChecklistMaintenance;
using MediatR;

namespace Application.Features.Settings.Checklist.ChecklistMaintenance.Checklists.Commands.UpdateChecklist
{
    public class UpdateChecklistHandler : IRequestHandler<UpdateChecklistRequest, Response<ChecklistFormDTO>>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IChecklistVersionRepository _checklistVersionRepository;
        private readonly IChecklistVersionQuestionsRepository _checklistVersionQuestionsRepository;
        private readonly IMapper _mapper;

        public UpdateChecklistHandler(
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
            UpdateChecklistRequest request,
            CancellationToken cancellationToken)
        {
            Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist? checklist = await _checklistRepository.GetByIdAsync(request.Id);

            if (checklist == null)
            {
                throw new NotFoundException("api-entity-checklist",
                    ("api-entity-checklist-field-id", request.Id)
                );
            }

            // Criar ChecklistVersion com novo Title
            ChecklistVersion checklistVersion = new ChecklistVersion(checklist.Id, request.Version.Title, request.Version.Key, 0);
            checklistVersion.IncrementVersion(checklist.Version?.Version ?? 0);
            checklistVersion.SetTitle(request.Version.Title);
            checklistVersion = await _checklistVersionRepository.InsertAsync(checklistVersion);

            checklist.SetVersion(checklistVersion);
            checklist.SetIsActive(request.IsActive);

            await _checklistRepository.UpdateAsync(checklist);

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

            checklist = await _checklistRepository.GetByIdWithVersions(checklist.Id);

            return new Response<ChecklistFormDTO>(_mapper.Map<ChecklistFormDTO>(checklist));
        }
    }
}
