﻿using Adapters.Repositories.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;

namespace Adapters.Repositories.Settings.LegalEntityCore.LegalEntities
{
    public interface ILegalEntityRepository :
        IGetByIdRepository<LegalEntity>,
        IInsertRepository<LegalEntity>,
        IUpdateRepository<LegalEntity>
    {
        IQueryable<LegalEntity> SearchToDashboard(
            string? filter,
            int current,
            int limit,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<LegalEntity> GetAllLegalEntities();
    }
}