namespace Hotel.Domain;
public class Categoria : BaseEntity
{
   public int Id { get; set; }
    public DateTime FechaDeEntrada { get; set; }
    public DateTime? FechaDeSalida { get; set; }
    public string Estado { get; set; } // Ejemplo: "Libre", "Ocupado", "Reservado"
    public int NumeroDeHabitacion { get; set; }
    public string NombreDelHuesped { get; set; }
    public string ApellidoDelHuesped { get; set; }
    public string DocumentoIdentificacion { get; set; }
    public void CheckIn()
    {
    }

    public void CheckOut()
}
