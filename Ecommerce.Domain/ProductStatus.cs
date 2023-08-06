using System.Runtime.Serialization;

namespace Ecommerce.Domain;

public enum ProductStatus
{
    [EnumMember(Value = "Produto Inativo")]
    Inativo = 1,
    [EnumMember(Value = "Produto Ativo")]
    Ativo = 2
}
