using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Queries.GetById
{
    internal class GetByIdHandler : IRequestHandler<GetByIdQuery,
        Response<CompactInspectionDTO?>>
    {
        private readonly ICompactInspectionRepository _compactInspectionRepository;
        private readonly IMapper _mapper;

        public GetByIdHandler(
            ICompactInspectionRepository compactInspectionRepository,
            IMapper mapper)
        {
            _compactInspectionRepository = compactInspectionRepository;
            _mapper = mapper;
        }

        public async Task<Response<CompactInspectionDTO?>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            var inspection = await _compactInspectionRepository.GetByIdAsync(query.Id);
            return new Response<CompactInspectionDTO?>(_mapper.Map<CompactInspectionDTO>(inspection));
        }
    }
}