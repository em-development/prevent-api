using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.DeleteLegalEntityContact;

public class DeleteLegalEntityContactRequest : LegalEntityContactDTO, IRequest<Response<bool>>
{
}
