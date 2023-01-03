using Application.Wrappers;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<UserFormDto>>
    {
        public int Id { get; set; }
    }
}