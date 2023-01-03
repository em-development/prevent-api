using Application.Wrappers;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Commands.UpdateUser;

public class UpdateUserRequest : UserFormDto, IRequest<Response<UserFormDto>>
{
}
