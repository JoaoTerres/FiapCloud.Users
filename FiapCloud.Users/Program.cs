using FiapCloud.Users.Api.Config;
using FiapCloud.Users.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabaseConfiguration(builder.Configuration)
    .AddRepositoryConfiguration()
    .AddMediatorConfiguration()
    .AddSwaggerConfiguration()
    .AddJwtConfiguration(builder.Configuration)      
    .AddAuthorizationConfiguration()
    .AddSecurityConfiguration();                

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwaggerConfiguration(app.Environment);

app.UseHttpsRedirection();

app.UseAuthentication();  
app.UseAuthorization();

app.MapControllers();

app.Run();
