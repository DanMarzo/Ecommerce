using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.ConfigBuilder;

public class UsuarioBuilder : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Id).HasMaxLength(36);
        builder.Property(x => x.NormalizedUserName).HasMaxLength(90);
    }
}
