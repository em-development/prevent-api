using Adapters.Repositories.Settings.PropertyCore.Properties;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.PropertyCore.Properties;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.GetById
{
    internal class GetByHandler : IRequestHandler<GetByIdQuery, Response<PropertyDTO>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetByHandler(
            IPropertyRepository propertyRepository,
            IMapper mapper
            )
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Response<PropertyDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            Property? property = await _propertyRepository.GetByIdAsync(query.Id);

            PropertyDTO? propertyDTO = _mapper.Map<PropertyDTO>(property);

            return new(propertyDTO);
        }
    }
}
