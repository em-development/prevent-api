using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplateVersions.Queries.GetByInspectionTemplateId
{
    internal class GetByChecklistIdHandler : IRequestHandler<GetByInspectionTemplateIdQuery, Response<IEnumerable<InspectionTemplateVersionDTO>>>
    {
        private readonly IInspectionTemplateVersionRepository _inspectionTemplateVersionRepository;
        private readonly IMapper _mapper;

        public GetByChecklistIdHandler(
            IInspectionTemplateVersionRepository inspectionTemplateVersionRepository,
            IMapper mapper
            )
        {
            _inspectionTemplateVersionRepository = inspectionTemplateVersionRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<InspectionTemplateVersionDTO>>> Handle(
            GetByInspectionTemplateIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<InspectionTemplateVersion>? inspectionTemplateVersions = await _inspectionTemplateVersionRepository.GetByInspectionTemplateId(query.Id);

            IEnumerable<InspectionTemplateVersionDTO>? result = _mapper.Map<IEnumerable<InspectionTemplateVersion>, IEnumerable<InspectionTemplateVersionDTO>>(inspectionTemplateVersions);

            return new(result);
        }

    }
}
