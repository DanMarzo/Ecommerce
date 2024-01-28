using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.ConfigBuilder;

public class ProductBuilder : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasMany(p => p.Reviews)
            .WithOne( p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Nome)
            .HasColumnType("NVARCHAR(100)");
        builder.Property(p => p.Preco)
            .HasColumnType("DECIMAL(10,2)");
        builder.Property(p => p.Descricao)
            .HasColumnType("NVARCHAR(4000)");
        builder.Property(p => p.Vendedor)
         .HasColumnType("NVARCHAR(100)");
    }
}
