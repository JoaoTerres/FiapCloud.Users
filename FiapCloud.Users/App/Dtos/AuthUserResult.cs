namespace FiapCloud.Users.App.Dtos;
public class AuthUserResult
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}
