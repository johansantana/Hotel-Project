namespace Hotel.Domain;
using System.ComponentModel.DataAnnotations;

public class Usuario : BaseEntity
{
    [Key]
    public required int IdUsuario { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Correo { get; set; }
    public string? Clave { get; set; }
    public int IdRolUsuario { get; set; }
}
