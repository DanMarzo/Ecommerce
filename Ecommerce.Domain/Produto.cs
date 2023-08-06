using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Produto : BaseDomainModel
{
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public string? Descricao { get; set; }
    public string? Vendedor { get; set; }
    public int Stock { get; set; }
    public ProductStatus Status { get; set; }
    public int CategoryId { get; set; }
}
