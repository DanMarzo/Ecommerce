using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.ConfigBuilder;

public class IdentityRoleBuilder : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.Property(x => x.Id).HasMaxLength(36);
        builder.Property(x => x.NormalizedName).HasMaxLength(90);
    }
}
