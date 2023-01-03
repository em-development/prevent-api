using Application.Wrappers;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.GetById
{
    public class GetAllQuery : IRequest<Response<IEnumerable<LegalEntityDTO>>>
    {
    }
}