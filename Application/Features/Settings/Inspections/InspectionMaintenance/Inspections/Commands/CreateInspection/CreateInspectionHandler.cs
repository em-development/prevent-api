using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Adapters.Services.BaseLogs;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Enums.Inspections.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.CreateInspection
{
    internal class CreateInspectionHandler : IRequestHandler<CreateInspectionRequest, Response<InspectionDTO>>
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IInspectionPropertyCoverageRepository _inspectionPropertyCoverageRepository;
        private readonly IInspectionPropertyBuildingRepository _inspectionPropertyBuildingRepository;
        private readonly IInspectionResponsableRepository _inspectionResponsableRepository;
        private readonly IInspectionAnswerRepository _inspectionAnswerRepository;
        private readonly IInspectionTemplateVersionRepository _inspectionTemplateVersionRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public CreateInspectionHandler(
            IInspectionRepository inspectionRepository,
            IInspectionPropertyCoverageRepository inspectionPropertyCoverageRepository,
            IInspectionPropertyBuildingRepository inspectionPropertyBuildingRepository,
            IInspectionResponsableRepository inspectionResponsableRepository,
            IInspectionAnswerRepository inspectionAnswerRepository,
            IInspectionTemplateVersionRepository inspectionTemplateVersionRepository,
            ILogService logService,
            IMapper mapper
            )
        {
            _inspectionRepository = inspectionRepository;
            _inspectionPropertyCoverageRepository = inspectionPropertyCoverageRepository;
            _inspectionPropertyBuildingRepository = inspectionPropertyBuildingRepository;
            _inspectionResponsableRepository = inspectionResponsableRepository;
            _inspectionAnswerRepository = inspectionAnswerRepository;
            _inspectionTemplateVersionRepository = inspectionTemplateVersionRepository;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<Response<InspectionDTO>> Handle(
            CreateInspectionRequest request,
            CancellationToken cancellationToken)
        {
            Inspection inspection = new(
                request.IsHighRisk,
                request.PropertyId,
                request.InspectorId,
                request.CoverageBegin,
                request.CoverageEnd,
                request.CoveragePremium,
                request.TemplateVersionId
            );

            inspection.SetStatus(InspectionStatusEnum.DRAFT);

            inspection = await _inspectionRepository.InsertAsync(inspection);

            if (request.PropertyCoverages != null)
            {
                foreach (var coverage in request.PropertyCoverages)
                {
                    await _inspectionPropertyCoverageRepository.InsertAsync(new InspectionPropertyCoverage(
                        inspection.Id,
                        coverage.CoverageId,
                        coverage.Coverage,
                        coverage.Value));
                }
            }

            if (request.Buildings != null)
            {
                foreach (var building in request.Buildings)
                {
                    await _inspectionPropertyBuildingRepository.InsertAsync(new InspectionPropertyBuilding(
                        inspection.Id,
                        building.Measures,
                        building.Description,
                        building.BuildingPattern,
                        building.BuildingPatternRate
                        ));
                }
            }

            if (request.Responsables != null)
            {
                foreach (var responsable in request.Responsables)
                {
                    await _inspectionResponsableRepository.InsertAsync(new InspectionResponsable(
                        inspection.Id,
                        responsable.Id
                        ));
                }
            }

            var inspectionTemplateVersion = await _inspectionTemplateVersionRepository.GetByIdWithChecklistsAndQuestions(request.TemplateVersionId);

            if (inspectionTemplateVersion != null)
            {
                foreach (var inspectionTemplateVersionChecklist in inspectionTemplateVersion.InspectionTemplateVersionChecklists)
                {
                    foreach (var checklistVersionQuestion in inspectionTemplateVersionChecklist.Checklist.Version.ChecklistVersionQuestions)
                    {
                        InspectionAnswer inspectionAnswer = new(
                            inspection.Id,
                            inspectionTemplateVersionChecklist.Checklist.Version.Id,
                            checklistVersionQuestion.Question.Version.Id
                            );

                        await _inspectionAnswerRepository.InsertAsync(inspectionAnswer);
                    }
                }
            }

            inspection = await _inspectionRepository.GetByIdWithIncludesAsync(inspection.Id);

            await _logService.DRAFT_SETTINGS_INSPECTION(inspection);

            return new Response<InspectionDTO>(_mapper.Map<InspectionDTO>(inspection));
        }
    }
}
