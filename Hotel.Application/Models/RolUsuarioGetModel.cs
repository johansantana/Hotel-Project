namespace Hotel.Application.Models;
using System.ComponentModel.DataAnnotations;

public class RolUsuarioGetModel
{
    [Key]
    public int IdRolUsuario { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();
}
