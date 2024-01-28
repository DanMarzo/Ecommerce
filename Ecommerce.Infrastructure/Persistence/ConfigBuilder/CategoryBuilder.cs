using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.ConfigBuilder;

public class CategoryBuilder : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Nombre).HasColumnType("NVARCHAR(100)");

        builder
            .HasMany(p => p.Products)
            .WithOne(r => r.Category)
            .HasForeignKey(r => r.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("1_PRODUCT_N_CATEGORY");
    }
}
