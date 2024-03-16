namespace Hotel.Api.Models
{
public class RecepcionGetModel
        {
            public int IdRecepcion { get; internal set; }
            public string? Huesped { get; internal set; }
            public string? FechaEntrada { get; internal set; }
            public string? FechaSalida { get; internal set; }
        }
    }
