namespace Hotel.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("EstadoHabitacion")]
public class EstadoHabitacion
{
    [Key]
    public int IdEstadoHabitacion { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();
}
