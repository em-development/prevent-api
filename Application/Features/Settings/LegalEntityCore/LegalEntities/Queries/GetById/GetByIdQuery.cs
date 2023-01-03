using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<LegalEntityDTO>>
    {
        public int Id { get; set; }
    }
}