using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetByIdToForm
{
    internal class GetByIdToFormHandler : IRequestHandler<GetByIdToFormQuery, Response<InspectionFormDTO>>
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;

        public GetByIdToFormHandler(
            IInspectionRepository inspectionRepository,
            IMapper mapper
            )
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
        }

        public async Task<Response<InspectionFormDTO>> Handle(
            GetByIdToFormQuery query,
            CancellationToken cancellationToken)
        {
            Inspection? inspection = await _inspectionRepository.GetByIdWithIncludesAsync(query.Id);

            InspectionFormDTO? inspectionDTO = _mapper.Map<InspectionFormDTO>(inspection);

            return new(inspectionDTO);
        }
    }

}
