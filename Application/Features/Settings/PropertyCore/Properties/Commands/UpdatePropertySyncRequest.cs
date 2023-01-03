using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Commands;

public class UpdatePropertySyncRequest : List<int>, IRequest<List<PropertyDTO>>
{
}
