using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.AuthUser;

public class AuthUserCommand : IRequest<Result<AuthUserResult>>
{
    public AuthUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}
