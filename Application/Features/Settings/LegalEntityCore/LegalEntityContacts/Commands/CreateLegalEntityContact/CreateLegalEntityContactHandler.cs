using Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Domain.Enums.Settings.Entities;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.CreateLegalEntityContact
{
    internal class CreateLegalEntityContactHandler : IRequestHandler<CreateLegalEntityContactRequest, Response<LegalEntityContactDTO>>
    {
        private readonly ILegalEntityContactRepository _legalEntityContactRepository;
        private readonly IMapper _mapper;

        public CreateLegalEntityContactHandler(
            ILegalEntityContactRepository legalEntityContactRepository,
            IMapper mapper
            )
        {
            _legalEntityContactRepository = legalEntityContactRepository;
            _mapper = mapper;
        }

        public async Task<Response<LegalEntityContactDTO>> Handle(
            CreateLegalEntityContactRequest request,
            CancellationToken cancellationToken)
        {
            LegalEntityContact contact = new LegalEntityContact(request.LegalEntity.Id, request.Name, request.Email, (LegalEntityContactTypeEnum)request.Type);

            contact = await _legalEntityContactRepository.InsertAsync(contact);

            return new Response<LegalEntityContactDTO>(_mapper.Map<LegalEntityContactDTO>(contact));
        }
    }
}
