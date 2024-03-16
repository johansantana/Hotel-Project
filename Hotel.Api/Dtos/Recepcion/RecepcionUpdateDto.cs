namespace Hotel.Api.Dtos.Recepcion;

public class RecepcionUpdateDto
{
    public int Id { get; set; }
    public DateTime? FechaDeSalida { get; set; }
    public string? Estado { get; set; }
}
