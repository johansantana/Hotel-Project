namespace Hotel.Api.Dtos.Recepcion;

public class RecepcionCreateDto
{
    public string? NombreDelHuesped { get; set; }
    public string? ApellidoDelHuesped { get; set; }
    public string? DocumentoIdentificacion { get; set; }
    public DateTime FechaDeEntrada { get; set; }
}
