namespace Hotel.Infrastructure;

public class Habitacion
{
    public int IdHabitacion { get; set; }
    public string? Numero { get; set; }
    public string? Detalle { get; set; }
    public float? Precio { get; set; }
    public EstadoHabitacion? EstadoHabitacion { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();

    // Falta -> Piso, Categoria
}
