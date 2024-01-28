using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain;

public class ShoppingCartItem : BaseDomainModel
{
    public string? Produto { get; set; }
    [Column(TypeName ="DECIMAL(10,2)")]
    public decimal Preco { get; set;}
    public int Quantidade { get; set; }
    public string? Imagem { get; set; }
    public string? Categoria { get; set; }
    public Guid? ShoppingCardMasterId { get; set; }
    public int ShoppingCartId { get; set; }
    public virtual ShoppingCart? ShoppingCart { get; set; }
    public int ProdutoId { get; set; }
    public int Stock { get; set; }
}
