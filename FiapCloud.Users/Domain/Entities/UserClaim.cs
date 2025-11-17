namespace FiapCloud.Users.Domain.Entities;

public class UserClaim
{
    public Guid UserId { get; private set; }
    public Guid ClaimId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private UserClaim() { }

    public UserClaim(Guid userId, Guid claimId)
    {
        UserId = userId;
        ClaimId = claimId;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }

    private void Validate()
    {
        AssertValidation.IsTrue(UserId != Guid.Empty, "UserId inválido.");
        AssertValidation.IsTrue(ClaimId != Guid.Empty, "ClaimId inválido.");
    }
}



