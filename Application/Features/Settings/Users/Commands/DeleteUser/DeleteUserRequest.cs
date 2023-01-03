using Application.Wrappers;
using MediatR;

namespace Application.Features.Settings.Users.Commands.DeleteUser;

public class DeleteUserRequest : IRequest<Response<bool>>
{
    public int Id { get; set; }
}