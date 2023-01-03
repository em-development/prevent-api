﻿using Adapters.Repositories.Base;
using Domain.Entities.Settings.Users;
using Domain.Enums.Settings.Users;

namespace Adapters.Repositories.Settings.Users
{
    public interface IUsersRepository :
        IGetByIdRepository<User>,
        IInsertRepository<User>,
        IUpdateRepository<User>,
        IRemoveRepository<User>
    {

        IQueryable<User> SearchToDashboard(
            string? filter,
            int current,
            int limit,
            string? orderDirection,
            string? orderBy
        );

        Task<User?> GetByUId(string uId);

        Task<IEnumerable<User>> GetInspectorsByLegalEntityId(int legalEntityId);
    }
}