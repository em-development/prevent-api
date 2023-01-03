using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Adapters.Repositories.Settings.LegalEntityCore.LegalEntitySyncs;
using Application.Exceptions.Common;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using Domain.Enums.Settings.Entities;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Commands
{
    public class UpdateLegalEntitySyncHandler : IRequestHandler<UpdateLegalEntitySyncRequest, List<LegalEntityDTO>>
    {
        private readonly ILegalEntityRepository _legalEntityRepository;
        private readonly ILegalEntitySyncRepository _legalEntitySyncRepository;
        private readonly IMapper _mapper;

        public UpdateLegalEntitySyncHandler(
            ILegalEntityRepository legalEntityRepository,
            ILegalEntitySyncRepository legalEntitySyncRepository,
            IMapper mapper
        )
        {
            _legalEntityRepository = legalEntityRepository;
            _legalEntitySyncRepository = legalEntitySyncRepository;
            _mapper = mapper;
        }

        public async Task<List<LegalEntityDTO>> Handle(
            UpdateLegalEntitySyncRequest request,
            CancellationToken cancellationToken)
        {
            var syncedEntities = new List<LegalEntityDTO>();

            foreach (var legalEntityId in request)
            {
                var corporateEntity = await _legalEntitySyncRepository.GetByIdAsync(legalEntityId);

                LegalEntity? preventParentEntity = null;

                if (corporateEntity == null)
                {
                    throw new NotFoundException("api-domain-entity-legal-entity-name",
                        ("ui-id", legalEntityId));
                }
                else if (corporateEntity.ParentId != null)
                {
                    preventParentEntity = await _legalEntityRepository.GetByIdAsync((int) corporateEntity.ParentId);
                }

                var preventEntity = await _legalEntityRepository.GetByIdAsync(legalEntityId);

                if (preventParentEntity == null && corporateEntity.ParentId != null)
                {
                    throw new PleaseSyncParentLegalEntity("LegalEntity",
                        ("id", corporateEntity.ParentId));
                }

                if (preventEntity == null)
                {
                    //INSERT
                    LegalEntity newEntity = new(
                        corporateEntity.Id,
                        corporateEntity.Name.Value,
                        corporateEntity.CodeEntity.Value,
                        corporateEntity.Status,
                        corporateEntity.ParentId,
                        (LegalEntityTypeEnum) corporateEntity.LegalEntityTypeId);

                    var syncedEntity = await _legalEntityRepository.InsertAsync(newEntity);

                    syncedEntities.Add(_mapper.Map<LegalEntityDTO>(syncedEntity));
                }
                else
                {
                    //UPDATE
                    LegalEntity updateEntity = new(
                        corporateEntity.Id,
                        corporateEntity.Name.Value,
                        corporateEntity.CodeEntity.Value,
                        corporateEntity.Status,
                        corporateEntity.ParentId,
                        (LegalEntityTypeEnum) corporateEntity.LegalEntityTypeId);

                    var syncedEntity = await _legalEntityRepository.UpdateAsync(updateEntity);

                    syncedEntities.Add(_mapper.Map<LegalEntityDTO>(syncedEntity));
                }

                corporateEntity.SetStatus(LegalEntitySyncStatusEnum.SYNCED);
                await _legalEntitySyncRepository.UpdateAsync(corporateEntity);
            }

            return await Task.FromResult(syncedEntities);
        }
    }
}