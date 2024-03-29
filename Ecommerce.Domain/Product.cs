﻿using Ecommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain;

public class Product : BaseDomainModel
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Nombre { get; set; }
    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Precio { get; set; }
    [Column(TypeName = "NVARCHAR(4000)")]
    public string? Descripcion { get; set; }
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Vendedor { get; set; }
    public int Stock { get; set; }
    public ProductStatus Status { get; set; } = ProductStatus.Ativo;
    public int Rating { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
    public virtual ICollection<Image>? Images { get; set; }
}
