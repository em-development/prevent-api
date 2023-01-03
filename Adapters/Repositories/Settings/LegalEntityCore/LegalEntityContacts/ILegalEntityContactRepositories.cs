﻿using Adapters.Repositories.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;

namespace Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts
{
    public interface ILegalEntityContactRepository :
        IGetByIdRepository<LegalEntityContact>,
        IInsertRepository<LegalEntityContact>,
        IUpdateRepository<LegalEntityContact>,
        IRemoveRepository<LegalEntityContact>
    {
        Task<IEnumerable<LegalEntityContact>> GetByLegalEntityId(
            int legalEntityId
        );
    }
}