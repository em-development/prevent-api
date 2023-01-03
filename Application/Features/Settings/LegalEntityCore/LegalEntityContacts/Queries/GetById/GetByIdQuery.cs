using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<LegalEntityContactDTO>>
    {
        public int Id { get; set; }
    }
}