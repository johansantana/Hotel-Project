namespace Hotel.Api.Models;
using System.ComponentModel.DataAnnotations;

public class EstadoHabitacionGetModel
{
    [Key]
    public int IdEstadoHabitacion { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();
}
