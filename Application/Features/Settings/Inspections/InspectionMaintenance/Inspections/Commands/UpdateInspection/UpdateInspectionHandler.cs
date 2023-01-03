using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.UpdateInspection
{
    public class UpdateInspectionHandler : IRequestHandler<UpdateInspectionRequest, Response<InspectionDTO>>
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IInspectionPropertyCoverageRepository _inspectionPropertyCoverageRepository;
        private readonly IInspectionPropertyBuildingRepository _inspectionPropertyBuildingRepository;
        private readonly IInspectionResponsableRepository _inspectionResponsableRepository;
        private readonly IMapper _mapper;

        public UpdateInspectionHandler(
            IInspectionRepository inspectionRepository,
            IInspectionPropertyCoverageRepository inspectionPropertyCoverageRepository,
            IInspectionPropertyBuildingRepository inspectionPropertyBuildingRepository,
            IInspectionResponsableRepository inspectionResponsableRepository,
            IMapper mapper
            )
        {
            _inspectionRepository = inspectionRepository;
            _inspectionPropertyCoverageRepository = inspectionPropertyCoverageRepository;
            _inspectionPropertyBuildingRepository = inspectionPropertyBuildingRepository;
            _inspectionResponsableRepository = inspectionResponsableRepository;
            _mapper = mapper;
        }

        public async Task<Response<InspectionDTO>> Handle(
            UpdateInspectionRequest request,
            CancellationToken cancellationToken)
        {
            Inspection? inspection = await _inspectionRepository.GetByIdAsync(request.Id);

            if (inspection == null)
            {
                throw new NotFoundException("api-entity-inspection",
                    ("api-entity-inspection-field-id", request.Id)
                );
            }

            #region Responsables

            var currentResponsables = await _inspectionResponsableRepository.GetByInspectionId(request.Id);

            var responsablesToDelete = currentResponsables.Where(p => request.Responsables.All(p2 => p2.Id != p.LegalEntityContactId));
            foreach (var item in responsablesToDelete)
            {
                await _inspectionResponsableRepository.RemoveAsync(item);
            }

            var responsablesToInsert = request.Responsables?.Where(p => currentResponsables.All(p2 => p2.LegalEntityContactId != p.Id));
            foreach (var item in responsablesToInsert)
            {
                InspectionResponsable responsable = new(
                    request.Id,
                    item.Id);

                await _inspectionResponsableRepository.InsertAsync(responsable);
            }

            #endregion

            #region Coverages

            var currentCoverages = await _inspectionPropertyCoverageRepository.GetByInspectionId(request.Id);

            var coveragesToDelete = currentCoverages.Where(p => request.PropertyCoverages.All(p2 => p2.Id != p.Id));
            foreach (var item in coveragesToDelete)
            {
                await _inspectionPropertyCoverageRepository.RemoveAsync(item);
            }

            var coveragesToInsert = request.PropertyCoverages.Where(p => currentCoverages.All(p2 => p2.Id != p.Id));
            foreach (var item in coveragesToInsert)
            {
                InspectionPropertyCoverage coverage = new(
                    request.Id,
                    item.CoverageId,
                    item.Coverage,
                    item.Value);

                await _inspectionPropertyCoverageRepository.InsertAsync(coverage);
            }

            #endregion

            #region Buildings

            var currentBuildings = await _inspectionPropertyBuildingRepository.GetByInspectionId(request.Id);

            var buildingsToDelete = currentBuildings.Where(p => request.Buildings.All(p2 => p2.Id != p.Id));
            foreach (var item in buildingsToDelete)
            {
                await _inspectionPropertyBuildingRepository.RemoveAsync(item);
            }

            var buildingsToInsert = request.Buildings.Where(p => currentBuildings.All(p2 => p2.Id != p.Id));
            foreach (var item in buildingsToInsert)
            {
                InspectionPropertyBuilding building = new(
                    request.Id,
                    item.Measures,
                    item.Description,
                    item.BuildingPattern,
                    item.BuildingPatternRate);

                await _inspectionPropertyBuildingRepository.InsertAsync(building);
            }

            #endregion

            inspection.SetInspectorId(request.InspectorId);
            inspection.SetIsHighRisk(request.IsHighRisk);
            inspection.SetPropertyId(request.PropertyId);
            inspection.SetTemplateVersionId(request.TemplateVersionId);

            await _inspectionRepository.UpdateAsync(inspection!);

            inspection = await _inspectionRepository.GetByIdWithIncludesAsync(inspection.Id);

            return new Response<InspectionDTO>(_mapper.Map<InspectionDTO>(inspection));
        }
    }
}
