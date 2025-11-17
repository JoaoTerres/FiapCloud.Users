using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Result<UserResult>>
{
    public CreateUserCommand(string username, string email, string passwordHash)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }

    public string Username { get; }
    public string Email { get; }
    public string PasswordHash { get; }
}
