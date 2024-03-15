namespace Hotel.Domain;
using System.ComponentModel.DataAnnotations;

public class EstadoHabitacion : BaseEntity
{
    [Key]
    public required int IdEstadoHabitacion { get; set; }
    public string? Descripcion { get; set; }
}
