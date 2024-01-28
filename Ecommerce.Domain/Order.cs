using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Order : BaseDomainModel
{
    public Order(
        string compradorNome,
        string compradorEmail,
        OrderAddress orderAddress,
        decimal subTotal,
        decimal total,
        decimal imposto,
        decimal frete
        )
    {
        CompradorNome = compradorNome;
        CompradorUsername = compradorEmail;
        OrderAddress = orderAddress;
        SubTotal = subTotal;
        Total = total;
        Imposto = imposto;
        Frete = frete;
    }
    public string? CompradorNome { get; set; }
    public string? CompradorUsername { get; set; }
    public OrderAddress? OrderAddress { get; set; }
    public IReadOnlyList<OrderItem>? OrderItems { get; set; }
    public decimal SubTotal { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal Total { get; set; }
    public decimal Imposto { get; set; }
    public decimal Frete { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? ClientSecret { get; set; }
    public string? StripeApiKey { get; set; }

}
