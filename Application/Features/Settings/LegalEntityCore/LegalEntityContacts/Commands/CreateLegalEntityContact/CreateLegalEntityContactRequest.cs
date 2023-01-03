using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Commands.CreateLegalEntityContact
{
    public class CreateLegalEntityContactRequest : LegalEntityContactDTO, IRequest<Response<LegalEntityContactDTO>>
    {
    }
}
