using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Adapters.Repositories.Settings.PropertyCore.Properties;
using Adapters.Repositories.Settings.PropertyCore.PropertySyncs;
using Adapters.Services.Settings.Properties;
using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.Entities.Settings.PropertyCore.PropertySyncs;
using Domain.Enums.Settings.Entities;
using Domain.Enums.Settings.Properties;
using DTO.Settings.PropertyCore.Properties;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Services.Settings.Properties
{
    public sealed class PropertySyncService : IPropertySyncService
    {
        private readonly IConfiguration _configuration;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertySyncRepository _propertySyncRepository;
        private readonly ILegalEntityRepository _legalEntityRepository;

        public PropertySyncService(
            IConfiguration configuration,
            IPropertyRepository propertyRepository,
            IPropertySyncRepository propertySyncRepository,
            ILegalEntityRepository legalEntityRepository
        )
        {
            _configuration = configuration;
            _propertyRepository = propertyRepository;
            _propertySyncRepository = propertySyncRepository;
            _legalEntityRepository = legalEntityRepository;
        }

        public async Task SyncProperties()
        {
            Console.WriteLine("========== Starting Sync Properties! =======");
            
            List<PropertyCorporateDto>? corporateProperties;
            var requestUrl = _configuration.GetSection("CorporateAPI").GetSection("URL").Value +
                             "prevent/get-all-properties";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(requestUrl))
                {
                    try
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        corporateProperties = JsonConvert.DeserializeObject<List<PropertyCorporateDto>>(apiResponse);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            var preventEntityIds = _legalEntityRepository
                .GetAllLegalEntities()
                .Select(x => x.Id)
                .ToList();

            corporateProperties = corporateProperties
                .Where(x => x.LegalEntity != null && preventEntityIds.Contains(x.LegalEntity.Id))
                .ToList();

            if (corporateProperties != null)
            {
                foreach (var corporateProperty in corporateProperties)
                {
                    var preventPropertySync = await _propertySyncRepository.GetByIdAsync(corporateProperty.Id);

                    var preventProperty = await _propertyRepository.GetByIdAsync(corporateProperty.Id);

                    if (preventPropertySync == null)
                    {
                        var legalEntity =
                            await _legalEntityRepository.GetByIdAsync(corporateProperty.LegalEntity.Id);

                        PropertySync newPropertySync = new(
                            corporateProperty.Id,
                            corporateProperty.Name,
                            corporateProperty.Address,
                            corporateProperty.Code,
                            corporateProperty.LegalEntity.Id,
                            (PropertyTypeEnum) corporateProperty.PropertyTypeId,
                            PropertySyncStatusEnum.SYNCED);

                        newPropertySync.SetStatus(CompareProperties(preventProperty, corporateProperty));

                        await _propertySyncRepository.InsertAsync(newPropertySync);
                    }
                    else
                    {
                        var currentStatusSync = CompareProperties(preventProperty, corporateProperty);

                        if (currentStatusSync == (PropertySyncStatusEnum) preventPropertySync.PropertySyncStatusId)
                            continue;

                        PropertySync updatePropertySync = new(
                            corporateProperty.Id,
                            corporateProperty.Name,
                            corporateProperty.Address,
                            corporateProperty.Code,
                            corporateProperty.LegalEntity.Id,
                            (PropertyTypeEnum) corporateProperty.PropertyTypeId,
                            CompareProperties(preventProperty, corporateProperty));

                        await _propertySyncRepository.UpdateAsync(updatePropertySync);
                    }
                }

                var query = _propertyRepository.GetAllProperties();
                var preventProperties = query.ToList();

                var notFoundProperties = preventProperties.ExceptBy(corporateProperties.Select(y => y.Id), x => x.Id);

                foreach (var property in notFoundProperties)
                {
                    PropertySync notFoundProperty = new(
                        property.Id,
                        property.Name.Value,
                        property.Address.Value,
                        property.Code?.Value,
                        property.LegalEntityId,
                        (PropertyTypeEnum) property.PropertyTypeId,
                        PropertySyncStatusEnum.NOT_EXIST);

                    await _propertySyncRepository.InsertAsync(notFoundProperty);
                }
            }
        }

        internal static PropertySyncStatusEnum CompareProperties(Property? preventProperty,
            PropertyCorporateDto corporateProperty)
        {
            if (preventProperty == null ||
                corporateProperty.Name != preventProperty.Name.Value ||
                corporateProperty.Address != preventProperty.Address.Value ||
                corporateProperty.Code != preventProperty.Code?.Value ||
                corporateProperty.PropertyTypeId != preventProperty.PropertyTypeId ||
                corporateProperty.LegalEntity != null &&
                corporateProperty.LegalEntity.Id != preventProperty.LegalEntityId ||
                corporateProperty.LegalEntity == null && preventProperty.LegalEntityId != 0
               )
            {
                return PropertySyncStatusEnum.PENDING;
            }

            return PropertySyncStatusEnum.SYNCED;
        }
    }
}