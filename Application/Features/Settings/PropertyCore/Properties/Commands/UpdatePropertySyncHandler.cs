using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Adapters.Repositories.Settings.PropertyCore.Properties;
using Adapters.Repositories.Settings.PropertyCore.PropertySyncs;
using Application.Exceptions.Common;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.Enums.Settings.Entities;
using Domain.Enums.Settings.Properties;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Commands
{
    public class UpdatePropertySyncHandler : IRequestHandler<UpdatePropertySyncRequest, List<PropertyDTO>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertySyncRepository _propertySyncRepository;
        private readonly ILegalEntityRepository _legalEntityRepository;
        private readonly IMapper _mapper;

        public UpdatePropertySyncHandler(
            IPropertyRepository propertyRepository,
            IPropertySyncRepository propertySyncRepository,
            ILegalEntityRepository legalEntityRepository,
            IMapper mapper
        )
        {
            _propertyRepository = propertyRepository;
            _propertySyncRepository = propertySyncRepository;
            _legalEntityRepository = legalEntityRepository;
            _mapper = mapper;
        }

        public async Task<List<PropertyDTO>> Handle(
            UpdatePropertySyncRequest request,
            CancellationToken cancellationToken)
        {
            List<PropertyDTO> syncedProperties = new List<PropertyDTO>();

            foreach (int propertyId in request)
            {
                PropertySync? corporateProperty = await _propertySyncRepository.GetByIdAsync(propertyId);

                Property? preventProperty = await _propertyRepository.GetByIdAsync(propertyId);

                LegalEntity? legalEntityProperty =
                    await _legalEntityRepository.GetByIdAsync(corporateProperty.LegalEntityId);
                if (legalEntityProperty == null)
                {
                    throw new PleaseSyncParentLegalEntity("LegalEntity",
                        ("id", corporateProperty.LegalEntityId.ToString()));
                }

                if (preventProperty == null)
                {
                    //INSERT
                    Property newProperty = new(
                        corporateProperty.Id,
                        corporateProperty.Name.Value,
                        corporateProperty.Address.Value,
                        corporateProperty.Code != null ? corporateProperty.Code.Value : null,
                        corporateProperty.LegalEntityId,
                        (PropertyTypeEnum) corporateProperty.PropertyTypeId);

                    var syncedProperty = await _propertyRepository.InsertAsync(newProperty);

                    syncedProperties.Add(_mapper.Map<PropertyDTO>(syncedProperty));
                }
                else
                {
                    //UPDATE
                    Property updateProperty = new(
                        corporateProperty.Id,
                        corporateProperty.Name.Value,
                        corporateProperty.Address.Value,
                        corporateProperty.Code != null ? corporateProperty.Code.Value : null,
                        corporateProperty.LegalEntityId,
                        (PropertyTypeEnum) corporateProperty.PropertyTypeId);

                    var syncedProperty = await _propertyRepository.UpdateAsync(updateProperty);

                    syncedProperties.Add(_mapper.Map<PropertyDTO>(syncedProperty));
                }

                corporateProperty.SetStatus(PropertySyncStatusEnum.SYNCED);
                await _propertySyncRepository.UpdateAsync(corporateProperty);
            }

            return await Task.FromResult(syncedProperties);
        }
    }
}