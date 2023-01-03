﻿using Adapters.Repositories.Base;
using Domain.Entities.Settings.Users;

namespace Adapters.Repositories.Settings.Users
{
    public interface IUsersProfilesRepository :
        IInsertRepository<UsersProfiles>,
        IUpdateRepository<UsersProfiles>,
        IRemoveRepository<UsersProfiles>
    {
        Task<IEnumerable<int>> GetUsersProfilesByUserId(
            int userId
        );

        Task<UsersProfiles?> GetByUserIdAndUserProfileId(
            int userId, 
            int userProfileId
        );

        Task RemoveAllByUserId(
            int userId
        );
    }
}