using FiapCloud.Users.App.Interfaces;
using FiapCloud.Users.Domain.Entities;
using System.IdentityModel.Tokens.Jwt; 
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace FiapCloud.Users.Infra.Security;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
        var issuer = _config["Jwt:Issuer"];
        var audience = _config["Jwt:Audience"];

        var claims = new List<System.Security.Claims.Claim>
        {
            new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new System.Security.Claims.Claim("username", user.Username),
            new System.Security.Claims.Claim("email", user.Email)
        };

        foreach (var role in user.Roles)
            claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, role.RoleId.ToString()));

        foreach (var c in user.Claims)
            claims.Add(new System.Security.Claims.Claim(c.ClaimId.ToString(), "true"));

        var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddHours(3),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
