namespace Hotel.Api.Models;

public class UsuarioGetModel
{
    public string? NombreCompleto { get; set; }
    public string? Correo { get; set; }
    public int IdRolUsuario { get; set; }
    public string? Clave { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();
}
