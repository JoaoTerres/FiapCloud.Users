using FiapCloud.Users.App.Interfaces;
using FiapCloud.Users.Infra.Security;
using Microsoft.AspNetCore.Identity;

namespace FiapCloud.Users.Api.Config;

public static class SecurityConfiguration
{
    public static IServiceCollection AddSecurityConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();

        return services;
    }
}

