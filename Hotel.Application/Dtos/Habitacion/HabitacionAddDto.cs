namespace Hotel.Application.Dtos;

public record HabitacionAddDto : HabitacionDtoBase
{
    public DateTime FechaCreacion { get; set; }
}
