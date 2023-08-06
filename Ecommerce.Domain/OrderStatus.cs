using System.Runtime.Serialization;

namespace Ecommerce.Domain;

public enum OrderStatus
{
    [EnumMember(Value ="Pendente")]
    Pending = 1,
    [EnumMember(Value = "O pagamento foi recebido")]
    Completed = 2,
    [EnumMember(Value = "O produto foi enviado")]
    Enviado = 3,
    [EnumMember(Value = "Erro no pagamento")]
    Erro = 4,
}
