using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntityContacts.Queries.GetById
{
    public class GetByLegalEntityIdQuery : IRequest<Response<IEnumerable<LegalEntityContactDTO>>>
    {
        public int Id { get; set; }
    }
}