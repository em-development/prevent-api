using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.GetById
{
    internal class GetByIdHandler : IRequestHandler<GetByIdQuery, Response<InspectionTemplateFormDTO>>
    {
        private readonly IInspectionTemplateRepository _inspectionTemplateRepository;
        private readonly IMapper _mapper;

        public GetByIdHandler(
            IInspectionTemplateRepository inspectionTemplateRepository,
            IMapper mapper
            )
        {
            _inspectionTemplateRepository = inspectionTemplateRepository;
            _mapper = mapper;
        }

        public async Task<Response<InspectionTemplateFormDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            InspectionTemplate? inspectionTemplate = await _inspectionTemplateRepository.GetByIdWithVersions(query.Id);

            InspectionTemplateFormDTO? inspectionTemplateDTO = _mapper.Map<InspectionTemplateFormDTO>(inspectionTemplate);

            return new(inspectionTemplateDTO);
        }
    }
}
