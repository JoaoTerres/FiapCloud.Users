namespace FiapCloud.Users.App.Dtos;

public class RoleResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ClaimResult> Claims { get; set; } = new();
}
