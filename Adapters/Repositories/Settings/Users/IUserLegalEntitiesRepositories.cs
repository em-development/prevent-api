﻿using Adapters.Repositories.Base;
using Domain.Entities.Settings.Users;

namespace Adapters.Repositories.Settings.Users
{
    public interface IUsersLegalEntitiesRepository :
        IInsertRepository<UsersLegalEntities>,
        IUpdateRepository<UsersLegalEntities>,
        IRemoveRepository<UsersLegalEntities>
    {
        Task<IEnumerable<int>> GetLegalEntitiesByUserId(
            int userId
        );

        Task<UsersLegalEntities?> GetByUserIdAndLegalEntityId(
            int userId,
            int legalEntityId
        );

        Task RemoveAllByUserId(
            int userId
        );
    }
}