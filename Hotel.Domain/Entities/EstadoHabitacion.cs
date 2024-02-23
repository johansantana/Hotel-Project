namespace Hotel.Domain;

public class EstadoHabitacion : BaseEntity
{
    public required int IdEstadoHabitacion { get; set; }
    public string? Descripcion { get; set; }
}
