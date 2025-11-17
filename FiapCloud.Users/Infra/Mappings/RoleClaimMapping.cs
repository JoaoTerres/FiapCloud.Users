using FiapCloud.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloud.Users.Infra.Mappings;
public class RoleClaimMapping : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("RoleClaims");

        builder.HasKey(rc => new { rc.RoleId, rc.ClaimId });

        builder.Property(rc => rc.CreatedAt)
            .IsRequired();
    }
}
