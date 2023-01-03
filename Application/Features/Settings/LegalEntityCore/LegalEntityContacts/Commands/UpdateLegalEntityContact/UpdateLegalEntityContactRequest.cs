using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.UpdateLegalEntityContact;

public class UpdateLegalEntityContactRequest : LegalEntityContactDTO, IRequest<Response<LegalEntityContactDTO>>
{
}
