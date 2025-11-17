using FiapCloud.Users.Infra.Repositories.Interfaces;
using FiapCloud.Users.Infra.Repository;

namespace FiapCloud.Users.Api.Config;

public static class RepositoryConfig
{
    public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IClaimRepository, ClaimRepository>();

        return services;
    }
}
