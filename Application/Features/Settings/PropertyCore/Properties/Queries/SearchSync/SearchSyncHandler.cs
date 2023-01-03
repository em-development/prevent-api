using Adapters.Repositories.Settings.PropertyCore.Properties;
using Adapters.Repositories.Settings.PropertyCore.PropertySyncs;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Enums.Settings.Properties;
using DTO.Settings.LegalEntityCore.LegalEntities;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.SearchSync
{
    internal class SearchSyncHandler : IRequestHandler<SearchSyncQuery, PagedResponse<IEnumerable<PropertySyncDTO>>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertySyncRepository _propertySyncRepository;
        private readonly IMapper _mapper;

        public SearchSyncHandler(
            IPropertyRepository propertyRepository,
            IPropertySyncRepository propertySyncRepository,
            IMapper mapper
        )
        {
            _propertyRepository = propertyRepository;
            _propertySyncRepository = propertySyncRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<PropertySyncDTO>>> Handle(
            SearchSyncQuery query,
            CancellationToken cancellationToken)
        {
            var propertySyncQuery = _propertySyncRepository.SearchToDashboard(
                filter: query.Filter,
                current: query.Current,
                limit: query.Limit,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy,
                onlyDifferent: query.OnlyDifferent
            );

            var corporateProperties = propertySyncQuery.Select(x => new
            {
                x.Id,
                Name = x.Name.Value,
                Code = x.Code != null ? x.Code.Value : null,
                x.PropertyTypeId,
                SyncStatus = (PropertySyncStatusEnum) x.PropertySyncStatusId,
                LegalEntity = x.LegalEntity != null ? _mapper.Map<LegalEntity, LegalEntityDTO>(x.LegalEntity) : null
            }).ToList();

            var preventPropertiesQuery = _propertyRepository.GetAllProperties(query.Filter);
            
            var preventProperties = preventPropertiesQuery.Select(x => new PropertyDTO()
            {
                Id = x.Id,
                Name = x.Name.Value,
                Code = x.Code != null ? x.Code.Value : string.Empty,
                PropertyTypeId = x.PropertyTypeId,
                LegalEntity = x.LegalEntity != null ? _mapper.Map<LegalEntity, LegalEntityDTO>(x.LegalEntity) : null
            }).ToList();

            var syncList = new List<PropertySyncDTO>();

            foreach (var item in corporateProperties)
            {
                var preventProperty = preventProperties
                    .FirstOrDefault(x => x.Id == item.Id);

                var syncEntity = new PropertySyncDTO()
                {
                    Corporate = new PropertyDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Code = item.Code,
                        PropertyTypeId = item.PropertyTypeId,
                        LegalEntity = item.LegalEntity
                    }
                };

                if (preventProperty != null)
                {
                    syncEntity.Prevent = new PropertyDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Code = item.Code,
                        PropertyTypeId = item.PropertyTypeId,
                        LegalEntity = item.LegalEntity
                    };
                }

                syncEntity.Status = item.SyncStatus;

                if (query.OnlyDifferent && syncEntity.Status == PropertySyncStatusEnum.PENDING)
                {
                    syncList.Add(syncEntity);
                }
                else if (!query.OnlyDifferent)
                {
                    syncList.Add(syncEntity);
                }
            }

            // var excludedIds = new HashSet<int>(corporateProperties.Select(p => p.Id));
            // var notExistInCorporate = preventProperties.Where(p => !excludedIds.Contains(p.Id));
            //
            // foreach (var item in notExistInCorporate)
            // {
            //     var syncEntity = new PropertySyncDTO()
            //     {
            //         Prevent = new PropertyDTO()
            //         {
            //             Id = item.Id,
            //             Name = item.Name,
            //             Code = item.Code,
            //             Status = item.Status,
            //             PropertyTypeId = item.PropertyTypeId,
            //             LegalEntityCore = item.LegalEntity
            //         },
            //         Status = PropertySyncStatusEnum.NOT_EXIST
            //     };
            //
            //     syncList.Add(syncEntity);
            // }

            return await syncList
                .OrderBy(x => x.Corporate?.Id ?? x.Prevent.Id)
                .Paginate(query.Current, query.Limit);
        }
    }
}