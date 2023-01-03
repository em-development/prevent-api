using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.SearchByPropertyTypeId
{
    internal class SearchByPropertyTypeIdHandler : IRequestHandler<SearchByPropertyTypeIdQuery, PagedResponse<IEnumerable<InspectionTemplateFormDTO>>>
    {
        private readonly IInspectionTemplateRepository _inspectionTemplateRepository;
        private readonly IMapper _mapper;

        public SearchByPropertyTypeIdHandler(
            IInspectionTemplateRepository inspectionTemplateRepository,
            IMapper mapper
            )
        {
            _inspectionTemplateRepository = inspectionTemplateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<InspectionTemplateFormDTO>>> Handle(
            SearchByPropertyTypeIdQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<InspectionTemplate> inspectionTemplates = _inspectionTemplateRepository.SearchByPropertyTypeId(
                propertyTypeId: query.PropertyTypeId,
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await inspectionTemplates.Paginate<InspectionTemplate, InspectionTemplateFormDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
