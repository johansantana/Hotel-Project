using Hotel.Domain.Core;

namespace Hotel.Domain;

public class Usuario : BaseEntity
{
    public required int IdUsuario { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Correo { get; set; }
    public string? Clave { get; set; }
    public int IdRolUsuario { get; set; }
}
