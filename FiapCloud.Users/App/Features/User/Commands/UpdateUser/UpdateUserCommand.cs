using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Result<UserResult>>
{
    public UpdateUserCommand(Guid id, string username, string email)
    {
        Id = id;
        Username = username;
        Email = email;
    }

    public Guid Id { get; }
    public string Username { get; }
    public string Email { get; }
}
