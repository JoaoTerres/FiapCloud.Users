namespace FiapCloud.Users.Domain.Entities;

public class RoleClaim
{
    public Guid RoleId { get; private set; }
    public Guid ClaimId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private RoleClaim() { }

    public RoleClaim(Guid roleId, Guid claimId)
    {
        RoleId = roleId;
        ClaimId = claimId;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }

    private void Validate()
    {
        AssertValidation.IsTrue(RoleId != Guid.Empty, "RoleId inválido.");
        AssertValidation.IsTrue(ClaimId != Guid.Empty, "ClaimId inválido.");
    }
}



