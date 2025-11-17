using FiapCloud.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloud.Users.Infra.Mappings;
public class ClaimMapping : IEntityTypeConfiguration<Claim>
{
    public void Configure(EntityTypeBuilder<Claim> builder)
    {
        builder.ToTable("Claims");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Type)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(c => c.Value)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.HasMany<UserClaim>()
            .WithOne()
            .HasForeignKey(uc => uc.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<RoleClaim>()
            .WithOne()
            .HasForeignKey(rc => rc.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
