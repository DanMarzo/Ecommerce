using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain;

public class Review :BaseDomainModel
{
    [Column(TypeName ="NVARCHAR(100)")]
    public string? Nome { get; set; }
    public int Rating { get; set; }
    [Column(TypeName = "NVARCHAR(4000)")]
    public string? Comentario { get; set; }
    public int ProductId { get; set; }
}
