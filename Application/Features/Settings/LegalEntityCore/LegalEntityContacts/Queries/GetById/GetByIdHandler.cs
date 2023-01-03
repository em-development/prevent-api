using Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Queries.GetById;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Queries.GetByIdHandler
{
    internal class GetByHandler : IRequestHandler<GetByIdQuery, Response<LegalEntityContactDTO>>
    {
        private readonly ILegalEntityContactRepository _legalEntityContactRepository;
        private readonly IMapper _mapper;

        public GetByHandler(
            ILegalEntityContactRepository legalEntityContactRepository,
            IMapper mapper
            )
        {
            _legalEntityContactRepository = legalEntityContactRepository;
            _mapper = mapper;
        }

        public async Task<Response<LegalEntityContactDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            LegalEntityContact? legalEntityContact = await _legalEntityContactRepository.GetByIdAsync(query.Id);

            LegalEntityContactDTO? legalEntityContactDTO = _mapper.Map<LegalEntityContactDTO>(legalEntityContact);

            return new(legalEntityContactDTO);
        }
    }
}
