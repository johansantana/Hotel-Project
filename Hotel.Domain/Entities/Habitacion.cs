namespace Hotel.Domain;

public class Habitacion : BaseEntity
{
    public required int IdHabitacion { get; set; }
    public string? Numero { get; set; }
    public string? Detalle { get; set; }
    public float Precio { get; set; }
    public int? IdEstadoHabitacion { get; set; }
    public int? IdPiso { get; set; }
    public int? IdCategoria { get; set; }

}
