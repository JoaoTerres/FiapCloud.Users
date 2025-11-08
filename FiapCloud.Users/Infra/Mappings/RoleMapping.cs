using FiapCloud.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloud.Users.Infra.Mappings;
public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name).IsRequired().HasColumnType("varchar(100)");
        builder.Property(r => r.Description).HasColumnType("varchar(250)");

        builder.HasMany<RoleClaim>()
               .WithOne()
               .HasForeignKey(rc => rc.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Roles");
    }
}
