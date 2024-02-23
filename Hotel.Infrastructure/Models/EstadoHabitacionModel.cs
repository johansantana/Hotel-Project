namespace Hotel.Infrastructure;

public class EstadoHabitacion
{
    public int IdEstadoHabitacion { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();
}
