using Adapters.Repositories.Settings.PropertyCore.Properties;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.GetByInspectionTemplateVersionId
{
    internal class GetByInspectionTemplateVersionIdHandler : IRequestHandler<GetByInspectionTemplateVersionIdQuery, Response<IEnumerable<int>?>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetByInspectionTemplateVersionIdHandler(
            IPropertyRepository propertyRepository,
            IMapper mapper
            )
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<int>?>> Handle(
            GetByInspectionTemplateVersionIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<int>? propertyTypeIds = await _propertyRepository.GetByInspectionTemplateVersionId(query.Id);

            return new(propertyTypeIds);
        }
    }
}
