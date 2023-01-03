using Adapters.Repositories.Settings.LegalEntityCore.LegalEntityContacts;
using Application.Exceptions.Common;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.DeleteLegalEntityContact;
using Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.UpdateLegalEntityContact;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using Domain.Enums.Settings.Entities;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Issues.Commands.DeleteLegalEntityContacts
{
    public class DeleteLegalEntityContactHandler : IRequestHandler<DeleteLegalEntityContactRequest, Response<bool>>
    {
        private readonly ILegalEntityContactRepository _legalEntityContactRepository;
        private readonly IMapper _mapper;

        public DeleteLegalEntityContactHandler(
            ILegalEntityContactRepository legalEntityContactRepository,
            IMapper mapper
            )
        {
            _legalEntityContactRepository = legalEntityContactRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(
            DeleteLegalEntityContactRequest request,
            CancellationToken cancellationToken)
        {
            LegalEntityContact? contact = await _legalEntityContactRepository.GetByIdAsync(request.Id);

            if (contact == null)
            {
                throw new NotFoundException("api-entity-legal-entity-contact",
                    ("api-entity--legal-entity-contact-field-id", request.Id)
                );
            }

            await _legalEntityContactRepository.RemoveAsync(contact);

            return new Response<bool>(data:true);
        }
    }
}
