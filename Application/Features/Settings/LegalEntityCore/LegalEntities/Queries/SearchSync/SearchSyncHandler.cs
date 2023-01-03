using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Adapters.Repositories.Settings.LegalEntityCore.LegalEntitySyncs;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using Domain.Enums.Settings.Entities;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.SearchSync
{
    internal class SearchSyncHandler : IRequestHandler<SearchSyncQuery, PagedResponse<IEnumerable<LegalEntitySyncDTO>>>
    {
        private readonly ILegalEntityRepository _legalEntityRepository;
        private readonly ILegalEntitySyncRepository _legalEntitySyncRepository;
        private readonly IMapper _mapper;

        public SearchSyncHandler(
            ILegalEntityRepository legalEntityRepository,
            ILegalEntitySyncRepository legalEntitySyncRepository,
            IMapper mapper
        )
        {
            _legalEntityRepository = legalEntityRepository;
            _legalEntitySyncRepository = legalEntitySyncRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LegalEntitySyncDTO>>> Handle(
            SearchSyncQuery query,
            CancellationToken cancellationToken)
        {
            var legalEntitySyncQuery = _legalEntitySyncRepository.GetAllLegalEntities(query.Filter);

            var corporateEntities = legalEntitySyncQuery.Select(x => new
            {
                x.Id,
                CodeEntity = x.CodeEntity.Value,
                Name = x.Name.Value,
                x.Status,
                SyncStatus = (LegalEntitySyncStatusEnum) x.LegalEntitySyncStatusId,
                Parent = x.Parent != null ? _mapper.Map<LegalEntitySync, LegalEntityDTO>(x.Parent) : null
            }).ToList();

            var preventEntitiesQuery = _legalEntityRepository.GetAllLegalEntities();

            var preventEntities = preventEntitiesQuery.Select(x => new LegalEntityDTO()
            {
                Id = x.Id,
                CodeEntity = x.CodeEntity.Value,
                Name = x.Name.Value,
                Status = x.Status,
                Parent = x.Parent != null ? _mapper.Map<LegalEntity, LegalEntityDTO>(x.Parent) : null
            }).ToList();

            var syncList = new List<LegalEntitySyncDTO>();

            foreach (var item in corporateEntities)
            {
                var preventEntity = preventEntities
                    .FirstOrDefault(x => x.Id == item.Id);

                var syncEntity = new LegalEntitySyncDTO()
                {
                    Corporate = new LegalEntityDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CodeEntity = item.CodeEntity,
                        Parent = item.Parent,
                        Status = item.Status
                    }
                };

                if (preventEntity != null)
                {
                    syncEntity.Prevent = new LegalEntityDTO()
                    {
                        Id = preventEntity.Id,
                        Name = preventEntity.Name,
                        CodeEntity = preventEntity.CodeEntity,
                        Parent = preventEntity.Parent,
                        Status = preventEntity.Status
                    };
                }

                syncEntity.Status = item.SyncStatus;

                if (query.OnlyDifferent && syncEntity.Status == LegalEntitySyncStatusEnum.PENDING)
                {
                    syncList.Add(syncEntity);
                }
                else if (!query.OnlyDifferent)
                {
                    syncList.Add(syncEntity);
                }
            }

            var excludedIds = new HashSet<int>(corporateEntities.Select(p => p.Id));
            var notExistInCorporate = preventEntities.Where(p => !excludedIds.Contains(p.Id));

            foreach (var item in notExistInCorporate)
            {
                var syncEntity = new LegalEntitySyncDTO()
                {
                    Prevent = new LegalEntityDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CodeEntity = item.CodeEntity,
                        Parent = item.Parent,
                        Status = item.Status
                    },
                    Status = LegalEntitySyncStatusEnum.NOT_EXIST
                };

                syncList.Add(syncEntity);
            }

            return await syncList
                .OrderBy(x => x.Corporate?.Id ?? x.Prevent?.Id)
                .Paginate(query.Current, query.Limit);
        }
    }
}