using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Domain.Configuration;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder
            .HasMany(p => p.ShoppingCartItems)
            .WithOne(p => p.ShoppingCart)
            .HasForeignKey(p => p.ShoppingCartId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
