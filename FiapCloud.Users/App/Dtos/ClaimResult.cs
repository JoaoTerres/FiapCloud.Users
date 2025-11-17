namespace FiapCloud.Users.App.Dtos;

public class ClaimResult
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public DateTime CreatedAt { get; set; }
}
