using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Enums.Settings.Entities;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Commands.CreateInspectionTemplate
{
    internal class CreateInspectionTemplateHandler : IRequestHandler<CreateInspectionTemplateRequest, Response<InspectionTemplateFormDTO>>
    {
        private readonly IInspectionTemplateRepository _checklistRepository;
        private readonly IInspectionTemplateVersionRepository _checklistVersionRepository;
        private readonly IInspectionTemplateVersionChecklistsRepository _checklistVersionChecklistsRepository;
        private readonly IInspectionTemplateVersionPropertyTypesRepository _checklistVersionPropertyTypesRepository;
        private readonly IMapper _mapper;

        public CreateInspectionTemplateHandler(
            IInspectionTemplateRepository checklistRepository,
            IInspectionTemplateVersionRepository checklistVersionRepository,
            IInspectionTemplateVersionChecklistsRepository checklistVersionChecklistsRepository,
            IInspectionTemplateVersionPropertyTypesRepository checklistVersionPropertyTypesRepository,
            IMapper mapper
            )
        {
            _checklistRepository = checklistRepository;
            _checklistVersionRepository = checklistVersionRepository;
            _checklistVersionChecklistsRepository = checklistVersionChecklistsRepository;
            _checklistVersionPropertyTypesRepository = checklistVersionPropertyTypesRepository;
            _mapper = mapper;
        }

        public async Task<Response<InspectionTemplateFormDTO>> Handle(
            CreateInspectionTemplateRequest request,
            CancellationToken cancellationToken)
        {
            InspectionTemplate inspectionTemplate = new InspectionTemplate(request.IsActive);
            inspectionTemplate = await _checklistRepository.InsertAsync(inspectionTemplate);

            InspectionTemplateVersion inspectionTemplateVersion = new InspectionTemplateVersion(inspectionTemplate.Id, request.Title, 0);
            inspectionTemplateVersion = await _checklistVersionRepository.InsertAsync(inspectionTemplateVersion);

            inspectionTemplate.SetVersion(inspectionTemplateVersion.Id);
            inspectionTemplate = await _checklistRepository.UpdateAsync(inspectionTemplate);

            if (request.Version != null)
            {
                if (request.Version.Checklists != null)
                {
                    foreach (int? checklistId in request.Version.Checklists.Select(x => x.ChecklistId))
                    {
                        await _checklistVersionChecklistsRepository.InsertAsync(new InspectionTemplateVersionChecklists(inspectionTemplateVersion.Id, checklistId.Value));
                    }
                }
            }

            if (request.Version != null)
            {
                if (request.Version.PropertyTypes != null)
                {
                    foreach (int propertyTypeId in request.Version.PropertyTypes)
                    {
                        await _checklistVersionPropertyTypesRepository.InsertAsync(new InspectionTemplateVersionPropertyTypes(inspectionTemplateVersion.Id, propertyTypeId));
                    }
                }
            }

            inspectionTemplate = await _checklistRepository.GetByIdWithVersions(inspectionTemplate.Id) ?? inspectionTemplate;

            return new Response<InspectionTemplateFormDTO>(_mapper.Map<InspectionTemplateFormDTO>(inspectionTemplate));
        }
    }
}
