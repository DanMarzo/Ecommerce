using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain;

public class Usuario : IdentityUser
{
    public String? Nombre { get; set; }
    public String? Apellido { get; set; }
    public String? Telefono { get; set; }
    public String? AvatarURL { get; set; }
    public bool IsActive { get; set; } = true;
}
