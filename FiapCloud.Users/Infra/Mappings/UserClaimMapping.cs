using FiapCloud.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloud.Users.Infra.Mappings;
public class UserClaimMapping : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.HasKey(uc => new { uc.UserId, uc.ClaimId });

        builder.Property(uc => uc.CreatedAt).IsRequired();

        builder.ToTable("UserClaims");
    }
}
