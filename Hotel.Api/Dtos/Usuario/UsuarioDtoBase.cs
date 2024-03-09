namespace Hotel.Api.Dtos;

public class UsuarioDtoBase : DtoBase
{
    public string? Clave { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Correo { get; set; }
    public int IdRolUsuario { get; set; }
}
