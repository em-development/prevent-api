using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Adapters.Repositories.Settings.LegalEntityCore.LegalEntitySyncs;
using Adapters.Services.Settings.LegalEntities;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.Enums.Settings.Entities;
using DTO.Settings.LegalEntityCore.LegalEntities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Services.Settings.LegalEntities
{
    public sealed class LegalEntitySyncService : ILegalEntitySyncService
    {
        private readonly IConfiguration _configuration;
        private readonly ILegalEntityRepository _legalEntityRepository;
        private readonly ILegalEntitySyncRepository _legalEntitySyncRepository;

        public LegalEntitySyncService(
            IConfiguration configuration,
            ILegalEntityRepository legalEntityRepository,
            ILegalEntitySyncRepository legalEntitySyncRepository
        )
        {
            _configuration = configuration;
            _legalEntityRepository = legalEntityRepository;
            _legalEntitySyncRepository = legalEntitySyncRepository;
        }

        public async Task SyncLegalEntities()
        {
            List<LegalEntityCorporateDTO>? corporateEntities;
            var requestUrl = _configuration.GetSection("CorporateAPI").GetSection("URL").Value +
                             "prevent/get-all-legal-entities";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(requestUrl))
                {
                    try
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        corporateEntities = JsonConvert.DeserializeObject<List<LegalEntityCorporateDTO>>(apiResponse);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            corporateEntities = GetChildren(null, new List<LegalEntityCorporateDTO>(), corporateEntities);

            foreach (var corporateEntity in corporateEntities)
            {
                var preventEntitySync = await _legalEntitySyncRepository.GetByIdAsync(corporateEntity.Id);

                var preventEntity = await _legalEntityRepository.GetByIdAsync(corporateEntity.Id);

                if (preventEntitySync == null)
                {
                    LegalEntitySync newEntitySync = new(
                        corporateEntity.Id,
                        corporateEntity.Name,
                        corporateEntity.CodeEntity,
                        corporateEntity.Status,
                        corporateEntity.Parent?.Id,
                        corporateEntity.TypeEnum,
                        LegalEntitySyncStatusEnum.SYNCED);

                    newEntitySync.SetStatus(CompareEntities(preventEntity, corporateEntity));

                    await _legalEntitySyncRepository.InsertAsync(newEntitySync);
                }
                else
                {
                    var currentStatusSync = CompareEntities(preventEntity, corporateEntity);

                    if (currentStatusSync != (LegalEntitySyncStatusEnum) preventEntitySync.LegalEntitySyncStatusId)
                    {
                        LegalEntitySync updateEntitySync = new(
                            corporateEntity.Id,
                            corporateEntity.Name,
                            corporateEntity.CodeEntity,
                            corporateEntity.Status,
                            corporateEntity.Parent?.Id,
                            corporateEntity.TypeEnum,
                            CompareEntities(preventEntity, corporateEntity));

                        await _legalEntitySyncRepository.UpdateAsync(updateEntitySync);
                    }
                }
            }

            var query = _legalEntityRepository.GetAllLegalEntities();
            var preventEntities = query.ToList();

            var notFoundEntities = preventEntities.ExceptBy(corporateEntities.Select(y => y.Id), x => x.Id);

            foreach (var entity in notFoundEntities)
            {
                LegalEntitySync notFoundEntity = new(
                    entity.Id,
                    entity.Name.Value,
                    entity.CodeEntity.Value,
                    entity.Status,
                    entity.Parent?.Id,
                    (LegalEntityTypeEnum) entity.LegalEntityTypeId,
                    LegalEntitySyncStatusEnum.NOT_EXIST);

                await _legalEntitySyncRepository.InsertAsync(notFoundEntity);
            }
        }

        internal static LegalEntitySyncStatusEnum CompareEntities(LegalEntity? preventEntity,
            LegalEntityCorporateDTO corporateEntity)
        {
            if (preventEntity == null ||
                corporateEntity.Name != preventEntity.Name.Value ||
                corporateEntity.CodeEntity != preventEntity.CodeEntity.Value ||
                corporateEntity.Status != preventEntity.Status ||
                corporateEntity.Parent != null && preventEntity.ParentId == null ||
                corporateEntity.Parent == null && preventEntity.ParentId != null ||
                corporateEntity.Parent != null && corporateEntity.Parent.Id != preventEntity.ParentId
               )
            {
                return LegalEntitySyncStatusEnum.PENDING;
            }

            return LegalEntitySyncStatusEnum.SYNCED;
        }

        public static List<LegalEntityCorporateDTO> GetChildren(int? id, List<LegalEntityCorporateDTO> hierarchy,
            List<LegalEntityCorporateDTO>? data)
        {
            if (data == null) return new List<LegalEntityCorporateDTO>();

            var children = data.Where(x => x.Parent?.Id == id);

            children = children.ToList();

            while (children.Any())
            {
                foreach (var child in children)
                {
                    hierarchy.Add(child);
                    GetChildren(child.Id, hierarchy, data);
                }

                return hierarchy;
            }

            return hierarchy;
        }
    }
}