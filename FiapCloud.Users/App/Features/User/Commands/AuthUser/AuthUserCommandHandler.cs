using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.App.Interfaces;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.AuthUser;


public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, Result<AuthUserResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;

    public AuthUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<Result<AuthUserResult>> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            throw new NotFoundException("User", request.Email);

        if (!user.IsActive)
            throw new ValidationException("Usuário está desativado.");

        var isValidPassword = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);

        if (!isValidPassword)
            throw new ValidationException("Credenciais inválidas.");

        var token = _jwtService.GenerateToken(user);

        var result = new AuthUserResult
        {
            UserId = user.Id,
            Email = user.Email,
            Token = token
        };

        return Result<AuthUserResult>.Ok(result, "Autenticação realizada com sucesso.");
    }
}
