using Application.Wrappers;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Commands.CreateUser
{
    public class CreateUserRequest : UserFormDto, IRequest<Response<UserFormDto>>
    {
    }
}
