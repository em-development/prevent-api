using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<InspectionTemplateDTO>>>
    {
        private readonly IInspectionTemplateRepository _inspectionTemplateRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            IInspectionTemplateRepository inspectionTemplateRepository,
            IMapper mapper
            )
        {
            _inspectionTemplateRepository = inspectionTemplateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<InspectionTemplateDTO>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<InspectionTemplate> inspectionTemplates = _inspectionTemplateRepository.SearchToDashboard(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await inspectionTemplates.Paginate<InspectionTemplate, InspectionTemplateDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
