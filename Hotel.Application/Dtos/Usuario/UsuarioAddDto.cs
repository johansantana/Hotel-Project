namespace Hotel.Application.Dtos;

public record UsuarioAddDto : UsuarioDtoBase
{
    public DateTime FechaCreacion { get; set; }
}
