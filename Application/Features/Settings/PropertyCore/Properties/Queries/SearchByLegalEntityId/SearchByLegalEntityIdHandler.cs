using Adapters.Repositories.Settings.PropertyCore.Properties;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.PropertyCore.Properties;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.Search
{
    internal class SearchByLegalEntityIdHandler : IRequestHandler<SearchByLegalEntityIdQuery, PagedResponse<IEnumerable<PropertyDTO>>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public SearchByLegalEntityIdHandler(
            IPropertyRepository propertyRepository,
            IMapper mapper
            )
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<PropertyDTO>>> Handle(
            SearchByLegalEntityIdQuery query,
            CancellationToken cancellationToken)
        {
            var properties = _propertyRepository.SearchByLegalEntityId(
                legalEntityId: query.LegalEntityId,
                filter: query.Filter,
                current: query.Current,
                limit: query.Limit,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await properties.Paginate<Property, PropertyDTO>(query.Current, query.Limit, _mapper);
        }
    }
}