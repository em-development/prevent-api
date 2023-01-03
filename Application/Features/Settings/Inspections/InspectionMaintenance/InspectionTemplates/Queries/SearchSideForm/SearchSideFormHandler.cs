using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.SearchSideForm
{
    internal class SearchSideFormHandler : IRequestHandler<SearchSideFormQuery, PagedResponse<IEnumerable<InspectionTemplateFormDTO>>>
    {
        private readonly IInspectionTemplateRepository _inspectionTemplateRepository;
        private readonly IMapper _mapper;

        public SearchSideFormHandler(
            IInspectionTemplateRepository inspectionTemplateRepository,
            IMapper mapper
            )
        {
            _inspectionTemplateRepository = inspectionTemplateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<InspectionTemplateFormDTO>>> Handle(
            SearchSideFormQuery query,
            CancellationToken cancellationToken)
        {
            IQueryable<InspectionTemplate> inspectionTemplates = _inspectionTemplateRepository.SearchToSideForm(
                filter: query.Filter,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await inspectionTemplates.Paginate<InspectionTemplate, InspectionTemplateFormDTO>(query.Current, query.Limit, _mapper);
        }
    }
}
