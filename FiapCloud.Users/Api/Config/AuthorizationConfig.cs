namespace FiapCloud.Users.Api.Config;


public static class AuthorizationConfig
{
    public static IServiceCollection AddAuthorizationConfiguration(
        this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanEditUsers", policy =>
                policy.RequireClaim("edit_users", "true"));

            options.AddPolicy("Admin", policy =>
                policy.RequireRole("admin"));
        });

        return services;
    }
}
