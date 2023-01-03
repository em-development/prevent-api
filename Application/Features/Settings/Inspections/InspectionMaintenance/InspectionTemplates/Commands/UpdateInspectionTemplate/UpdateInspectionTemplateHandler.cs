using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Enums.Settings.Entities;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Commands.UpdateInspectionTemplate
{
    public class UpdateInspectionTemplateHandler : IRequestHandler<UpdateInspectionTemplateRequest, Response<InspectionTemplateFormDTO>>
    {
        private readonly IInspectionTemplateRepository _inspectionTemplateRepository;
        private readonly IInspectionTemplateVersionRepository _inspectionTemplateVersionRepository;
        private readonly IInspectionTemplateVersionChecklistsRepository _inspectionTemplateVersionChecklistsRepository;
        private readonly IInspectionTemplateVersionPropertyTypesRepository _inspectionTemplateVersionPropertyTypesRepository;
        private readonly IMapper _mapper;

        public UpdateInspectionTemplateHandler(
            IInspectionTemplateRepository inspectionTemplateRepository,
            IInspectionTemplateVersionRepository inspectionTemplateVersionRepository,
            IInspectionTemplateVersionChecklistsRepository inspectionTemplateVersionChecklistsRepository,
            IInspectionTemplateVersionPropertyTypesRepository inspectionTemplateVersionPropertyTypesRepository,
            IMapper mapper
            )
        {
            _inspectionTemplateRepository = inspectionTemplateRepository;
            _inspectionTemplateVersionRepository = inspectionTemplateVersionRepository;
            _inspectionTemplateVersionChecklistsRepository = inspectionTemplateVersionChecklistsRepository;
            _inspectionTemplateVersionPropertyTypesRepository = inspectionTemplateVersionPropertyTypesRepository;
            _mapper = mapper;
        }

        public async Task<Response<InspectionTemplateFormDTO>> Handle(
            UpdateInspectionTemplateRequest request,
            CancellationToken cancellationToken)
        {
            InspectionTemplate? inspectionTemplate = await _inspectionTemplateRepository.GetByIdAsync(request.Id);

            if (inspectionTemplate == null)
            {
                throw new NotFoundException("api-entity-inspection",
                    ("api-entity-inspection-template-field-id", request.Id)
                );
            }

            // Criar ChecklistVersion com novo Title
            InspectionTemplateVersion inspectionTemplateVersion = new InspectionTemplateVersion(inspectionTemplate.Id, request.Version.Title, 0);
            inspectionTemplateVersion.IncrementVersion(inspectionTemplate.Version?.Version ?? 0);
            inspectionTemplateVersion.SetTitle(request.Version.Title);
            inspectionTemplateVersion = await _inspectionTemplateVersionRepository.InsertAsync(inspectionTemplateVersion);

            inspectionTemplate.SetVersion(inspectionTemplateVersion);
            inspectionTemplate.SetIsActive(request.IsActive);

            await _inspectionTemplateRepository.UpdateAsync(inspectionTemplate);

            if (request.Version != null)
            {
                if (request.Version.Checklists != null)
                {
                    foreach (int? checklistId in request.Version.Checklists.Select(x => x.ChecklistId))
                    {
                        await _inspectionTemplateVersionChecklistsRepository.InsertAsync(new InspectionTemplateVersionChecklists(inspectionTemplateVersion.Id, checklistId.Value));
                    }
                }
            }

            if (request.Version != null)
            {
                if (request.Version.PropertyTypes != null)
                {
                    foreach (int propertyTypeId in request.Version.PropertyTypes)
                    {
                        await _inspectionTemplateVersionPropertyTypesRepository.InsertAsync(new InspectionTemplateVersionPropertyTypes(inspectionTemplateVersion.Id, propertyTypeId));
                    }
                }
            }

            inspectionTemplate = await _inspectionTemplateRepository.GetByIdWithVersions(inspectionTemplate.Id);

            return new Response<InspectionTemplateFormDTO>(_mapper.Map<InspectionTemplateFormDTO>(inspectionTemplate));
        }
    }
}
