﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Domain.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasMany(p => p.Reviews)
            .WithOne( p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.Images)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Nombre)
            .HasColumnType("NVARCHAR(100)");
        builder.Property(p => p.Precio)
            .HasColumnType("DECIMAL(10,2)");
        builder.Property(p => p.Descripcion)
            .HasColumnType("NVARCHAR(4000)");
        builder.Property(p => p.Vendedor)
         .HasColumnType("NVARCHAR(100)");
    }
}
