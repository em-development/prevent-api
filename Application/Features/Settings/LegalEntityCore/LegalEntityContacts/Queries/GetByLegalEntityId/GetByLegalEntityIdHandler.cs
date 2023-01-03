using Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Queries.GetById;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Queries.GetByLegalEntityId
{
    internal class GetByLegalEntityIdHandler : IRequestHandler<GetByLegalEntityIdQuery, Response<IEnumerable<LegalEntityContactDTO>>>
    {
        private readonly ILegalEntityContactRepository _legalEntityContactRepository;
        private readonly IMapper _mapper;

        public GetByLegalEntityIdHandler(
            ILegalEntityContactRepository legalEntityContactRepository,
            IMapper mapper
            )
        {
            _legalEntityContactRepository = legalEntityContactRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<LegalEntityContactDTO>>> Handle(
            GetByLegalEntityIdQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<LegalEntityContact>? legalEntityContact = await _legalEntityContactRepository.GetByLegalEntityId(query.Id);

            IEnumerable<LegalEntityContactDTO>? legalEntityContactDTO = _mapper.Map<IEnumerable<LegalEntityContact>, IEnumerable<LegalEntityContactDTO>>(legalEntityContact);

            return new(legalEntityContactDTO);
        }
    }
}
