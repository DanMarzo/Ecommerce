using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(o => o.OrderAddress, x => x.WithOwner());

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(o => o.Status).HasConversion(
            o => o.ToString(),
            o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
            );
        builder.Property(o => o.SubTotal)
            .HasColumnType("Decimal(10,2)");

        builder.Property(o => o.Total)
            .HasColumnType("Decimal(10,2)");

        builder.Property(o => o.Imposto)
            .HasColumnType("Decimal(10,2)");

        builder.Property(o => o.Frete)
            .HasColumnType("Decimal(10,2)");
    }
}
