namespace Hotel.Application.Dtos;

public record RolUsuarioAddDto : RolUsuarioDtoBase
{
    public DateTime FechaCreacion { get; set; }
}
