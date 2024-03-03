namespace Hotel.Infrastructure;

public class RecepcionModel
{
  
    public int ID { get; set; }
    public int NumeroHab { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public string? Nombre { get; set; } // Ahora se espera que siempre tenga un valor.
    public string? EstadoReserva { get; set; } // Igualmente, siempre debe tener un valor.
}
