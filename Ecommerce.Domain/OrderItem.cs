using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain;

public class OrderItem : BaseDomainModel
{
    public Product? Produto { get; set; }
    public int ProdutoId { get; set; }
    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public Order? Order { get; set; }
    public int OrderId { get; set; }
    public int ProdutoItemId { get; set; }
    public string? ProdutoNome { get; set; }
    public string? ImagemUrl { get; set; }
}

