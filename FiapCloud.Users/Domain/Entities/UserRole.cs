namespace FiapCloud.Users.Domain.Entities;

public class UserRole
{
    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private UserRole() { }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }

    private void Validate()
    {
        AssertValidation.IsTrue(UserId != Guid.Empty, "UserId inválido.");
        AssertValidation.IsTrue(RoleId != Guid.Empty, "RoleId inválido.");
    }
}


