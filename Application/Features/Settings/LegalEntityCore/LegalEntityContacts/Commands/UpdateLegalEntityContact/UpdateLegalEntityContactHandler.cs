using Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Domain.Enums.Settings.Entities;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.UpdateLegalEntityContact
{
    public class UpdateLegalEntityContactHandler : IRequestHandler<UpdateLegalEntityContactRequest, Response<LegalEntityContactDTO>>
    {
        private readonly ILegalEntityContactRepository _legalEntityContactRepository;
        private readonly IMapper _mapper;

        public UpdateLegalEntityContactHandler(
            ILegalEntityContactRepository legalEntityContactRepository,
            IMapper mapper
            )
        {
            _legalEntityContactRepository = legalEntityContactRepository;
            _mapper = mapper;
        }

        public async Task<Response<LegalEntityContactDTO>> Handle(
            UpdateLegalEntityContactRequest request,
            CancellationToken cancellationToken)
        {
            LegalEntityContact? contact = await _legalEntityContactRepository.GetByIdAsync(request.Id);

            if (contact == null)
            {
                throw new NotFoundException("api-entity-legal-entity-contact",
                    ("api-entity--legal-entity-contact-field-id", request.Id)
                );
            }

            contact.Update(request.Name, request.Email, (LegalEntityContactTypeEnum)request.Type);

            await _legalEntityContactRepository.UpdateAsync(contact);

            contact = await _legalEntityContactRepository.GetByIdAsync(contact.Id);

            return new Response<LegalEntityContactDTO>(_mapper.Map<LegalEntityContactDTO>(contact));
        }
    }
}
