using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.LegalEntities.Commands;

public class UpdateLegalEntitySyncRequest : List<int>, IRequest<List<LegalEntityDTO>>
{
}
