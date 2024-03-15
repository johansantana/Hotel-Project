namespace Hotel.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Usuario")]
public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Correo { get; set; }
    public int IdRolUsuario { get; set; }
    public string? Clave { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();
}
