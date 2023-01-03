using Adapters.Repositories.Settings.PropertyCore.Properties;
using Application.Features.Settings.PropertyCore.Properties.Queries.GetPropertyTypes;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.PropertyCore.Properties;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.Search
{
    internal class GetPropertyTypesHandler : IRequestHandler<GetPropertyTypesQuery, Response<IEnumerable<PropertyTypeDTO>>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetPropertyTypesHandler(
            IPropertyRepository propertyRepository,
            IMapper mapper
            )
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<PropertyTypeDTO>>> Handle(
            GetPropertyTypesQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<PropertyType>? propertyTypes = await _propertyRepository.GetPropertyTypes();

            IEnumerable<PropertyTypeDTO>? propertyTypesDTO = _mapper.Map<IEnumerable<PropertyType>, IEnumerable<PropertyTypeDTO>>(propertyTypes);

            propertyTypesDTO = propertyTypesDTO.OrderBy(x => x.Description);

            return new(propertyTypesDTO);
        }
    }
}