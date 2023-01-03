using Application.Wrappers;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.GetPropertyTypes
{
    public class GetPropertyTypesQuery : FilterParams, IRequest<Response<IEnumerable<PropertyTypeDTO>>>
    {
    }
}