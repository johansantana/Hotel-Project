namespace Hotel.Application.Dtos;

public record UsuarioDtoBase : DtoBase
{

    public string? Clave { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Correo { get; set; }
    public int IdRolUsuario { get; set; }
}
