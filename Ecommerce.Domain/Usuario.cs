using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain;

public class Usuario : IdentityUser
{
    public String? Nome { get; set; }
    public String? Sobrenome { get; set; }
    public String? Telefone { get; set; }
    public String? AvatarURL { get; set; }
    public bool IsActive { get; set; } = true;
}
