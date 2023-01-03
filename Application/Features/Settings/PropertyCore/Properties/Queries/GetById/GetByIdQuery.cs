using Application.Wrappers;
using DTO.Settings.PropertyCore.Properties;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<PropertyDTO>>
    {
        public int Id { get; set; }
    }
}